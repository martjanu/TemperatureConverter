using TemperaturConverter.ConsoleCLient.Interfaces;
using TemperaturConverter.ConsoleCLient.Validators;

namespace TemperaturConverter.ConsoleCLient.Factories;

public class TemperatureValidatorFactory
{
    public ITemperatureValidator Create() => new TemperatureValidator();
}
