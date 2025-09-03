namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureUnit
{
    public double ToKelvin(double value);
    public double FromKelvin(double value);
}