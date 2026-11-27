from sense_hat import SenseHat
import requests
import time

sense = SenseHat()

API_URL = "https://fridgeaid-csdahrcgdxg3eycv.germanywestcentral-01.azurewebsites.net/api/Measurements"

while True:
    try:
        temperature = sense.get_temperature()
        humidity = sense.get_humidity()

        payload = {
            "temperature": round(temperature, 1),
            "humidity": round(humidity, 1)
        }

        response = requests.post(API_URL, json=payload, timeout=10)
        response.raise_for_status()

        print(f"Temperatur: {temperature:.1f} C | Luftfugtighed: {humidity:.1f} % | Status: {response.status_code}")

    except Exception as e:
        print(f"Fejl: {e}")

    time.sleep(2)