using TemperaturConverter.Application.Factories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;
using TemperatureConverter.UI;

var service = TemperatureFactory.CreateService();
var validator = TemperatureFactory.CreateValidator();
var clientIteraction = TemperatureFactory.CreateITeraction();

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
    clientIteraction.WriteOutput("Enter temperature unit to convert from (Celsius, Fahrenheit, Bananas, Kelvin):");
    var fromUnit = repository.GetTemperatureUnit(clientIteraction.ReadInput()) ?? throw new ArgumentException("Invalid temperature unit provided.");
    clientIteraction.WriteOutput("Enter temperature unit to convert to (Celsius, Fahrenheit, Bananas, Kelvin):");
    var toUnit = repository.GetTemperatureUnit(clientIteraction.ReadInput()) ?? throw new ArgumentException("Invalid temperature unit provided.");
    clientIteraction.WriteOutput("Enter temperature value to convert:");
    var inputValue = validator.TryParseTemperature(clientIteraction.ReadInput()) ?? throw new ArgumentException("Invalid temperature value provided.");

    var result = service.Convert(
        fromUnit,
        toUnit,
        inputValue
    );

    clientIteraction.WriteOutput($"{result}");
}
catch (ArgumentException ex)
{
    clientIteraction.WriteOutput($"Input error: {ex.Message}");
}

 