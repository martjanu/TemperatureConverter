using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Units;

public class FahrenheitUnit : ITemperatureUnit
{
    public double ToKelvin(double value)
    {
        return (value - 32) * 5 / 9 + 273.15;
    }

    public double FromKelvin(double value)
    {
        return (value - 273.15) * 9 / 5 + 32;
    }
}