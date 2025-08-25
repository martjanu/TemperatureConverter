namespace TemperaturConverter.Domain.Interfaces;

public interface IValidator
{
    public decimal? TryParseTemperature(string input);
}
