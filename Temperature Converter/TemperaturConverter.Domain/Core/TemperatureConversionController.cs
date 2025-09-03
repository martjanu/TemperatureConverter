using TemperaturConverter.Domain.Core.Factories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;

namespace TemperaturConverter.Domain.Core;

public class TemperatureConversionController
{
    private readonly ITemperatureService _service;
    private readonly ITemperatureValidator _validator;
    private readonly IUserInteraction _interaction;
    private readonly ITemperatureUnitRepository _repository;

    public TemperatureConversionController()
    {
        var temperatureServiceFactory = new TemperatureServiceFactory();
        _service = temperatureServiceFactory.Create();

        var validatorFactory = new TemperatureValidatorFactory();
        _validator = validatorFactory.Create();

        var interactionFactory = new UserInteractionFactory();
        _interaction = interactionFactory.Create();

        var repositoryFactory = new TemperatureUnitRepositoryFactory();
        _repository = repositoryFactory.Create(
            new Dictionary<string, ITemperatureUnit>(StringComparer.OrdinalIgnoreCase)
            {
                ["celsius"] = new CelsiusUnit(),
                ["fahrenheit"] = new FahrenheitUnit(),
                ["bananas"] = new BananasUnit(),
                ["kelvin"] = new KelvinUnit()
            });
    }

    public void Convert()
    {
        try
        {
            var fromUnit = AskForUnit("Enter temperature unit to convert from:");
            var toUnit = AskForUnit("Enter temperature unit to convert to:");
            var value = AskForTemperature("Enter temperature value to convert:");

            var result = _service.Convert(fromUnit, toUnit, value);
            _interaction.WriteOutput($"Result: {result}");
        }
        catch (ArgumentException ex)
        {
            _interaction.WriteOutput($"Input error: {ex.Message}");
        }
    }

    private ITemperatureUnit AskForUnit(string prompt)
    {
        _interaction.WriteOutput(prompt);
        var input = _interaction.ReadInput();
        var unit = _repository.GetTemperatureUnit(input);

        if (unit == null)
            throw new ArgumentException("Invalid temperature unit provided.");

        return unit;
    }

    private double AskForTemperature(string prompt)
    {
        _interaction.WriteOutput(prompt);
        var input = _interaction.ReadInput();
        var value = _validator.TryParseTemperature(input);

        if (value == null)
            throw new ArgumentException("Invalid temperature value provided.");

        return value.Value;
    }
}