using TemperaturConverter.Application.Controllers;
using TemperaturConverter.Application.Factories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;

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

var controller = new TemperatureConversionController(
    service,
    validator,
    clientInteraction,
    repository);

controller.Run();
