using TemperaturConverter.Domain.Interfaces;


namespace TemperaturConverter.Domain.Models;

public class KelvinUnit : ITemperatureUnit
{
    public string Name { get; } = "Kelvin";

    public decimal ToKelvin(decimal value)
    {
        return value;
    }

    public decimal FromKelvin(decimal value)
    {
        return value;
    }
}