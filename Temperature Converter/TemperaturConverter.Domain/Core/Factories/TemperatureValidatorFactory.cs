using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Validators;

namespace TemperaturConverter.Domain.Core.Factories;

public class TemperatureValidatorFactory
{
    public ITemperatureValidator Create() => new TemperatureValidator();
}
