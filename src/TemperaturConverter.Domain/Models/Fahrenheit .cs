using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Models;

public class FahrenheitUnit : ITemperatureUnit
{
    public string Name { get; } = "Fahrenheit";

    public double ToKelvin(double value)
    {
        return (value - 32) * 5 / 9 + 273.15;
    }

    public double FromKelvin(double value)
    {
        return (value - 273.15) * 9 / 5 + 32;
    }
}