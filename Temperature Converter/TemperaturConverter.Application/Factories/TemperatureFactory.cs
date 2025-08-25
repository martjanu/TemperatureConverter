using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Application.Services;
using TemperaturConverter.Application.Repositories;
using TemperaturConverter.Domain.Validators;
using TemperatureConverter.UI;

namespace TemperaturConverter.Application.Factories;

public class TemperatureFactory : ITemperatureFactory
{
    public static ITemperatureService CreateService()
    {
        return new TemperatureUnitService();
    }

    public static ITemperatureRepository CreateRepository(Dictionary<string, ITemperatureUnit> units)
    {
        return new TemperatureUnitRepository(units);
    }

    public static ITemperatureValidator CreateValidator()
    {
        return new TemperatureValidator();
    }

    public static IClientInteraction CreateInteraction()
    {
        return new ConsoleAction();
    }
}
