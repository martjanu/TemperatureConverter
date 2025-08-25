using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Application.Services;

public class TemperatureUnitService : ITemperatureService
{
    public decimal Convert(ITemperatureUnit fromUnit, ITemperatureUnit toUnit, decimal value)
    {
        var amount = fromUnit.ToKelvin(value);
        return toUnit.FromKelvin(amount);
    }
}
