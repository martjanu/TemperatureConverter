using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Core.Services;

namespace TemperaturConverter.Domain.Core.Factories;

public class TemperatureServiceFactory
{
    public ITemperatureService Create() => new TemperatureUnitService();
}
