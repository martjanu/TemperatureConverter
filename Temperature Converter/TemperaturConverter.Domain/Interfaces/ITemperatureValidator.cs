namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureValidator
{
    public decimal? TryParseTemperature(string input);
}
