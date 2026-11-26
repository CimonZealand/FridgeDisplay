const apiBaseUrl = document.getElementById("app").dataset.apiBaseUrl;
const latestMeasurementUrl = new URL("/api/measurements/latest", apiBaseUrl).href;

function getReadingStatus(value, minimum, maximum) {
    if (!Number.isFinite(value)) {
        return { level: "neutral", label: "Ingen måling" };
    }

    if (value < minimum || value > maximum) {
        return { level: "warning", label: "Uden for interval" };
    }

    return { level: "optimal", label: "Optimal" };
}

Vue.createApp({
    data() {
        return {
            measurement: null,
            requestState: "loading",
            pollTimer: null
        };
    },
    computed: {
        temperature() {
            return this.measurement?.temperature;
        },
        humidity() {
            return this.measurement?.humidity;
        },
        temperatureStatus() {
            return getReadingStatus(this.temperature, 2, 5);
        },
        humidityStatus() {
            return getReadingStatus(this.humidity, 50, 75);
        },
        summaryStatus() {
            if (this.requestState === "loading") {
                return { level: "neutral", label: "Henter måling" };
            }

            if (this.requestState === "error") {
                return { level: "neutral", label: "Kan ikke hente målinger" };
            }

            const levels = [this.temperatureStatus.level, this.humidityStatus.level];
            if (levels.includes("warning")) {
                return { level: "warning", label: "Advarsel" };
            }

            if (levels.includes("neutral")) {
                return { level: "neutral", label: "Måling mangler" };
            }

            return { level: "optimal", label: "Optimal" };
        }
    },
    mounted() {
        this.loadLatestMeasurement();
        this.pollTimer = window.setInterval(() => this.loadLatestMeasurement(), 10000);
    },
    beforeUnmount() {
        window.clearInterval(this.pollTimer);
    },
    methods: {
        async loadLatestMeasurement() {
            try {
                const response = await axios.get(latestMeasurementUrl, { timeout: 5000 });
                this.measurement = response.status === 204 ? null : response.data;
                this.requestState = "ready";
            } catch {
                this.measurement = null;
                this.requestState = "error";
            }
        }
    }
}).mount("#app");
