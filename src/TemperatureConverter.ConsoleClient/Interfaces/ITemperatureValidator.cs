namespace TemperaturConverter.ConsoleCLient.Interfaces;

public interface ITemperatureValidator
{
    public double? TryParseTemperature(string input);
}
