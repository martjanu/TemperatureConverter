using TemperaturConverter.ConsoleCLient.Interfaces;

namespace TemperaturConverter.ConsoleCLient.Validators;

public class TemperatureValidator : ITemperatureValidator
{
    public double? TryParseTemperature(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        return double.TryParse(input, out var value)
            ? value
            : null;
    }
}
