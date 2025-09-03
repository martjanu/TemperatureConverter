using TemperaturConverter.Domain.Core.Repositories;
using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Core.Factories;

public class TemperatureUnitRepositoryFactory
{
    public ITemperatureUnitRepository Create(Dictionary<string, ITemperatureUnit>? units = null)
        => new TemperatureUnitRepository(units);
}
