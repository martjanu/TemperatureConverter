using TemperaturConverter.Domain.Core.Factories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;
using TemperatureConverter.Controllers;

namespace TemperaturConverter.Factories;

public class TemperatureConverterControllerFactory
{
    public TemperatureConversionConsoleController Create()
    {
        var temperatureServiceFactory = new TemperatureServiceFactory();
        var service = temperatureServiceFactory.Create();

        var validatorFactory = new TemperatureValidatorFactory();
        var validator = validatorFactory.Create();

        var interactionFactory = new UserInteractionFactory();
        var interaction = interactionFactory.Create();

        var repositoryFactory = new TemperatureUnitRepositoryFactory();
        var repository = repositoryFactory.Create(
            new Dictionary<string, ITemperatureUnit>(StringComparer.OrdinalIgnoreCase)
            {
                ["celsius"] = new CelsiusUnit(),
                ["fahrenheit"] = new FahrenheitUnit(),
                ["bananas"] = new BananasUnit(),
                ["kelvin"] = new KelvinUnit()
            });

        return new TemperatureConversionConsoleController(service, validator, interaction, repository);
    }
}
