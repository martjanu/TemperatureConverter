using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Services;

public class TemperatureService : ITemperatureService
{
    public double Convert(ITemperatureUnit fromUnit, ITemperatureUnit toUnit, double value)
    {
        if (fromUnit is null)
            throw new ArgumentNullException(nameof(fromUnit));
        if (toUnit is null)
            throw new ArgumentNullException(nameof(toUnit));

        var kelvinValue = fromUnit.ToKelvin(value);
        return toUnit.FromKelvin(kelvinValue);
    }
}
