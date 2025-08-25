using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Models;

public class FahrenheitUnit : ITemperatureUnit
{
    public string Name { get; } = "Fahrenheit";

    public decimal ToKelvin(decimal value)
    {
        return (value - 32) * 5 / 9 + 273.15m;
    }

    public decimal FromKelvin(decimal value)
    {
        return (value - 273.15m) * 9 / 5 + 32;
    }
}