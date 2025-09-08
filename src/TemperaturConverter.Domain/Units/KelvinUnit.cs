using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Units;

public class KelvinUnit : ITemperatureUnit
{
    public double ToKelvin(double value)
    {
        return value;
    }

    public double FromKelvin(double value)
    {
        return value;
    }
}