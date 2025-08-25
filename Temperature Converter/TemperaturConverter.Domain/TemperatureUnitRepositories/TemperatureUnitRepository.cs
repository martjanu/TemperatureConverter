using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;

namespace TemperaturConverter.Domain.TemperatureUnitRepositories;

public class TemperatureUnitRepository : ITemperatureUnitRepository
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
