using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Application.Controllers;

public class TemperatureConversionController
{
    private readonly ITemperatureService _service;
    private readonly ITemperatureValidator _validator;
    private readonly IClientInteraction _interaction;
    private readonly ITemperatureRepository _repository;

    public TemperatureConversionController(
    ITemperatureService service,
        ITemperatureValidator validator,
        IClientInteraction interaction,
        ITemperatureRepository repository)
    {
        _service = service;
        _validator = validator;
        _interaction = interaction;
        _repository = repository;
    }

    public void Run()
    {
        try
        {
            var fromUnit = AskForUnit("Enter temperature unit to convert from (Celsius, Fahrenheit, Bananas, Kelvin):");
            var toUnit = AskForUnit("Enter temperature unit to convert to (Celsius, Fahrenheit, Bananas, Kelvin):");
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

    private decimal AskForTemperature(string prompt)
    {
        _interaction.WriteOutput(prompt);
        var input = _interaction.ReadInput();
        var value = _validator.TryParseTemperature(input);

        if (value == null)
            throw new ArgumentException("Invalid temperature value provided.");

        return value.Value;
    }
}