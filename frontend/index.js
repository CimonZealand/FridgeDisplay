Vue.createApp({
    data() {
        return {
            temperature: 4.2,
            humidity: 65
        }
    },
    methods: {
        sayHello() {
            this.message = "Hello " + this.name;
        }
    }
}).mount('#app');

