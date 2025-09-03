using TemperaturConverter.Domain.Core.Factories;

var controllerFactory = new TemperatureConverterControllerFactory();
var controller = controllerFactory.Create();
controller.Convert();
