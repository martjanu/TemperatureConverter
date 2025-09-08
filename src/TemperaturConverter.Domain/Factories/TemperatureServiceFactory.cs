using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Services;

namespace TemperaturConverter.Domain.Factories;

public class TemperatureServiceFactory
{
    public ITemperatureService Create() => new TemperatureService();
}
