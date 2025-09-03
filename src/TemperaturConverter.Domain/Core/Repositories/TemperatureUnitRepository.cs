using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Core.Repositories;

public class TemperatureUnitRepository : ITemperatureUnitRepository
{
    private readonly Dictionary<string, ITemperatureUnit> _temperatureUnits;

    public TemperatureUnitRepository(Dictionary<string, ITemperatureUnit>? temperatureUnits)
    {
        _temperatureUnits = temperatureUnits ?? new Dictionary<string, ITemperatureUnit>(StringComparer.OrdinalIgnoreCase);
    }

    public ITemperatureUnit? GetTemperatureUnit(string name)
    {
        _temperatureUnits.TryGetValue(name, out var unit);
        return unit;
    }

    public string GetUnitNames()
    {
        if (_temperatureUnits.Count == 0)
            return "No temperature units registered.";

        var sb = new System.Text.StringBuilder();
        foreach (var key in _temperatureUnits.Keys.OrderBy(k => k))
        {
            sb.AppendLine($"- {key}");
        }
        return sb.ToString();
    }
}
