using TemperaturConverter.Domain.Interfaces;


namespace TemperaturConverter.Domain.Models;

public class BananasUnit : ITemperatureUnit
{
    public string Name { get; } = "Bananas";

    public decimal ToKelvin(decimal value)
    {
        return value * 30m;
    }

    public decimal FromKelvin(decimal value)
    {
        return value / 30m;
    }
}