namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureUnit
{
    public decimal ToKelvin(decimal value);
    public decimal FromKelvin(decimal value);
}