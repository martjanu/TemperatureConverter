using TemperaturConverter.Factories;

var controllerFactory = new TemperatureConverterControllerFactory();
var controller = controllerFactory.Create();
controller.Convert();
