using TemperaturConverter.Domain.Interfaces;


namespace TemperaturConverter.Domain.Models;

public class BananasUnit : ITemperatureUnit
{
    public string Name { get; } = "Bananas";

    public double ToKelvin(double value)
    {
        return value * 30;
    }

    public double FromKelvin(double value)
    {
        return value / 30;
    }
}