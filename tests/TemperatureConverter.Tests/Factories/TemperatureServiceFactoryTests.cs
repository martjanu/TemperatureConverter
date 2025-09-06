using TemperaturConverter.Domain.Core.Factories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Core.Services;

namespace TemperaturConverter.Tests.Factories;

public class TemperatureServiceFactoryTests
{
    [Fact]
    public void Create_ShouldReturn_NotNull()
    {
        // Arrange
        var factory = new TemperatureServiceFactory();

        // Act
        var service = factory.Create();

        // Assert
        Assert.NotNull(service);
    }

    [Fact]
    public void Create_ShouldReturn_ITemperatureService()
    {
        // Arrange
        var factory = new TemperatureServiceFactory();

        // Act
        var service = factory.Create();

        // Assert
        Assert.IsAssignableFrom<ITemperatureService>(service);
    }

    [Fact]
    public void Create_ShouldReturn_TemperatureServiceInstance()
    {
        // Arrange
        var factory = new TemperatureServiceFactory();

        // Act
        var service = factory.Create();

        // Assert
        Assert.IsType<TemperatureService>(service);
    }
}
