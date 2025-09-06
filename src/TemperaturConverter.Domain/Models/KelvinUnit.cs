using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Models;

public class KelvinUnit : ITemperatureUnit
{
    public string Name { get; } = "Kelvin";

    public double ToKelvin(double value)
    {
        return value;
    }

    public double FromKelvin(double value)
    {
        return value;
    }
}