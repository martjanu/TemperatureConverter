using TemperaturConverter.Domain.Factories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Units;
using TemperatureConverter.ConsoleCLient.Controllers;
using TemperaturConverter.ConsoleCLient.Factories;
using TemperaturConverter.ConsoleCLient.Interfaces;

namespace TemperaturConverter.ConsoleCLient.Factories;

public class TemperatureConverterControllerFactory
{
    private readonly ITemperatureService _service;
    private readonly ITemperatureValidator _validator;
    private readonly IUserInteraction _interaction;
    private readonly ITemperatureUnitRepository _repository;

    public TemperatureConverterControllerFactory(
        ITemperatureService service,
        ITemperatureValidator validator,
        IUserInteraction interaction,
        ITemperatureUnitRepository repository)
    {
        _interaction = interaction ?? throw new ArgumentNullException(nameof(interaction));
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public TemperatureConversionController Create() 
        => new TemperatureConversionController(_service, _validator, _interaction, _repository);
}
