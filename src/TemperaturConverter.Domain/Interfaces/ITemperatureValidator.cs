namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureValidator
{
    public double? TryParseTemperature(string input);
}
