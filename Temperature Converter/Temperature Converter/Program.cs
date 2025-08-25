using TemperaturConverter.Application.Factories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;
using TemperatureConverter.UI;

var service = TemperatureFactory.CreateService();
var validator = TemperatureFactory.CreateValidator();
var clientInteraction = TemperatureFactory.CreateInteraction();

var repository = TemperatureFactory.CreateRepository(
    new Dictionary<string, ITemperatureUnit>(StringComparer.OrdinalIgnoreCase)
    {
        ["celsius"] = new CelsiusUnit(),
        ["fahrenheit"] = new FahrenheitUnit(),
        ["bananas"] = new BananasUnit(),
        ["kelvin"] = new KelvinUnit()
    });

try
{
    clientInteraction.WriteOutput("Enter temperature unit to convert from (Celsius, Fahrenheit, Bananas, Kelvin):");
    var fromUnit = repository.GetTemperatureUnit(clientInteraction.ReadInput()) ?? throw new ArgumentException("Invalid temperature unit provided.");
    clientInteraction.WriteOutput("Enter temperature unit to convert to (Celsius, Fahrenheit, Bananas, Kelvin):");
    var toUnit = repository.GetTemperatureUnit(clientInteraction.ReadInput()) ?? throw new ArgumentException("Invalid temperature unit provided.");
    clientInteraction.WriteOutput("Enter temperature value to convert:");
    var inputValue = validator.TryParseTemperature(clientInteraction.ReadInput()) ?? throw new ArgumentException("Invalid temperature value provided.");

    var result = service.Convert(
        fromUnit,
        toUnit,
        inputValue
    );

    clientInteraction.WriteOutput($"{result}");
}
catch (ArgumentException ex)
{
    clientInteraction.WriteOutput($"Input error: {ex.Message}");
}

 