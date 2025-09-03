using System.Globalization;
using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Validators;

public class TemperatureValidator : ITemperatureValidator
{
    public double? TryParseTemperature(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        return double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out var value)
            ? value
            : null;
    }
}
