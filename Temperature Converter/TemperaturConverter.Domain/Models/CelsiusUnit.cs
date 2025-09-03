using TemperaturConverter.Domain.Interfaces;


namespace TemperaturConverter.Domain.Models;

public class CelsiusUnit : ITemperatureUnit
{
    public string Name { get; } = "Celsius";

    public double ToKelvin(double value)
    {
        return value + 273.15;
    }

    public double FromKelvin(double value)
    {
        return value - 273.15;
    }
}