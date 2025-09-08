using TemperaturConverter.Domain.Factories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Services;

namespace TemperaturConverter.DOmain.Tests.Factories;

public class TemperatureServiceFactoryTests
{
    private readonly TemperatureServiceFactory _factory;
    private readonly ITemperatureService _instance1;
    private readonly ITemperatureService _instance2;

    public TemperatureServiceFactoryTests()
    { 
        _factory = new TemperatureServiceFactory();
         
        _instance1 = _factory.Create();
        _instance2 = _factory.Create();
    }

    [Fact]
    public void Create_ShouldReturnNonNullInstance()
    {
        // Act
        var result = _factory.Create();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Create_ShouldReturnNewInstanceEachTime()
    {
        // Act & Assert
        Assert.NotSame(_instance1, _instance2);
    }

    [Fact]
    public void Create_ShouldReturnTemperatureServiceConcreteType()
    {
        // Act
        var result = _factory.Create();

        // Assert
        Assert.IsType<TemperatureService>(result);
    }
}
