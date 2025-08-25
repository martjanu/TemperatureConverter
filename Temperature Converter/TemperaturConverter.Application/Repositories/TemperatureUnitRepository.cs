using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;

namespace TemperaturConverter.Application.Repositories;

public class TemperatureUnitRepository : ITemperatureRepository
{
    private readonly Dictionary<string, ITemperatureUnit> _temperatureUnits;
    public TemperatureUnitRepository(Dictionary<string, ITemperatureUnit>? temperatureUnits)
    {
        _temperatureUnits = temperatureUnits ?? new Dictionary<string, ITemperatureUnit>(StringComparer.OrdinalIgnoreCase);
    }

    public ITemperatureUnit? GetTemperatureUnit(string name)
    {
        if (_temperatureUnits.TryGetValue(name, out var unit))
            return unit;
        return null;
    }
}
