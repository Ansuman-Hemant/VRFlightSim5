using TMPro;
using UnityEngine;

public class WeatherUI : MonoBehaviour
{
    [SerializeField] Rigidbody planeRb;
    [SerializeField] TextMeshProUGUI weatherText;

    void Update()
    {
        string temp = Utility.KelvinToCelcius(Weather.GetTemperature(planeRb.position.y)).ToString("0.00");
        string airPressure = Weather.GetAirPressure(planeRb.position.y).ToString("0.00");
        string airDensity = Weather.GetAirDensity(planeRb.position.y).ToString("0.00");

        weatherText.text = $"Temperature: {temp} C\n\nAir Pressure: {airPressure} Pa\n\nAir Density: {airDensity} Kg/m^3";
    }
}
