using TemperaturConverter.Domain.Interfaces;


namespace TemperaturConverter.Domain.Models;

public class CelsiusUnit : ITemperatureUnit
{
    public string Name { get; } = "Celsius";

    public decimal ToKelvin(decimal value)
    {
        return value + 273.15m;
    }

    public decimal FromKelvin(decimal value)
    {
        return value - 273.15m;
    }
}