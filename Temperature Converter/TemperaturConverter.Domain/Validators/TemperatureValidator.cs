using System.Globalization;
using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Validators;

public class TemperatureValidator : IValidator
{
    public decimal? TryParseTemperature(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
        {
            return value;
        }

        return null;
    }
}
