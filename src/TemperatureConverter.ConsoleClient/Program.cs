using TemperaturConverter.ConsoleCLient.Factories;
using TemperaturConverter.Domain.Factories;

var temperatureServiceFactory = new TemperatureServiceFactory();
var service = temperatureServiceFactory.Create();

var validatorFactory = new TemperatureValidatorFactory();
var validator = validatorFactory.Create();

var interactionFactory = new UserInteractionFactory();
var interaction = interactionFactory.Create();

var repositoryFactory = new TemperatureUnitRepositoryFactory();
var repository = repositoryFactory.Create();

var controllerFactory = new TemperatureConverterControllerFactory(service, validator, interaction, repository);
var controller = controllerFactory.Create();
controller.Convert();
