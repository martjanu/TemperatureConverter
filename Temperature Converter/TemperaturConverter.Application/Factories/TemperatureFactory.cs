using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Application.Services;
using TemperaturConverter.Domain.TemperatureUnitRepositories;
using TemperaturConverter.Domain.Validators;
using TemperatureConverter.UI;

namespace TemperaturConverter.Application.Factories;

public class TemperatureFactory
{
    public static ITemperatureService CreateService()
    {
        return new TemperatureUnitService();
    }

    public static ITemperatureUnitRepository CreateRepository(Dictionary<string, ITemperatureUnit> units)
    {
        return new TemperatureUnitRepository(units);
    }

    public static IValidator CreateValidator()
    {
        return new TemperatureValidator();
    }

    public static IInteraction CreateITeraction()
    {
        return new ConsoleAction();
    }
}
