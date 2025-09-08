using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Units;

public class BananasUnit : ITemperatureUnit
{
    public double ToKelvin(double value)
    {
        return value * 30;
    }

    public double FromKelvin(double value)
    {
        return value / 30;
    }
}