using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Units;

public class CelsiusUnit : ITemperatureUnit
{
    public double ToKelvin(double value)
    {
        return value + 273.15;
    }

    public double FromKelvin(double value)
    {
        return value - 273.15;
    }
}