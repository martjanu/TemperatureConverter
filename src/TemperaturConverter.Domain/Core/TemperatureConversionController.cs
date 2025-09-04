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

    public TemperatureConversionController(
        ITemperatureService service, 
        ITemperatureValidator validator,
        IUserInteraction interaction,
        ITemperatureUnitRepository repository)
    {
        _interaction = interaction;
        _service = service;
        _validator = validator;
        _repository = repository;
    }

    public void Convert()
    {
        try
        {
            _interaction.WriteOutput(_repository.GetUnitNames());
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