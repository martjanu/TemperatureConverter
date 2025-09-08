using TemperaturConverter.Domain.Repositories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Units;

namespace TemperaturConverter.Domain.Factories;

public class TemperatureUnitRepositoryFactory
{
    private readonly Dictionary<string, ITemperatureUnit> _units;

    public TemperatureUnitRepositoryFactory()
    {
        _units = new Dictionary<string, ITemperatureUnit>(StringComparer.OrdinalIgnoreCase)
        {
            ["celsius"] = new CelsiusUnit(),
            ["fahrenheit"] = new FahrenheitUnit(),
            ["bananas"] = new BananasUnit(),
            ["kelvin"] = new KelvinUnit()
        };
    }

    public ITemperatureUnitRepository Create()
        => new TemperatureUnitRepository(_units);
}
