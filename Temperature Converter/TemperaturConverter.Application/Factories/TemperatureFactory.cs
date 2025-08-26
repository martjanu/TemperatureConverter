using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Application.Services;
using TemperaturConverter.Application.Repositories;
using TemperaturConverter.Domain.Validators;
using TemperatureConverter.UI;

namespace TemperaturConverter.Application.Factories;

public static class TemperatureFactory
{
    public static ITemperatureService CreateService() => new TemperatureUnitService();

    public static ITemperatureRepository CreateRepository(Dictionary<string, ITemperatureUnit>? units = null)
        => new TemperatureUnitRepository(units ?? new Dictionary<string, ITemperatureUnit>());

    public static ITemperatureValidator CreateValidator() => new TemperatureValidator();

    public static IClientInteraction CreateInteraction() => new ConsoleAction();

    public static TemperatureConversionController CreateController() => new TemperatureConversionController();
}
