using TemperaturConverter.ConsoleCLient.Factories;
using TemperaturConverter.ConsoleCLient.Validators;
using TemperaturConverter.ConsoleCLient.Interfaces;

namespace TemperaturConverter.ConsoleCLient.Tests.Factories;

public class TemperatureValidatorFactoryTests
{
    private readonly TemperatureValidatorFactory _factory;
    private readonly ITemperatureValidator _instance1;
    private readonly ITemperatureValidator _instance2;

    public TemperatureValidatorFactoryTests()
    {
        _factory = new TemperatureValidatorFactory();
        _instance1 = _factory.Create();
        _instance2 = _factory.Create();
    }

    [Fact]
    public void Create_ShouldReturnNonNullInstance()
    {
        var result = _factory.Create();
        Assert.NotNull(result);
    }

    [Fact]
    public void Create_ShouldReturnNewInstanceEachTime()
    {
        Assert.NotSame(_instance1, _instance2);
    }
}
