using TemperaturConverter.Factories;
using TemperatureConverter.Controllers;

namespace TemperaturConverter.Tests.Factories;

public class TemperatureConverterControllerFactoryTests
{
    [Fact]
    public void Create_ShouldReturn_NotNull()
    {
        // Arrange
        var factory = new TemperatureConverterControllerFactory();

        // Act
        var controller = factory.Create();

        // Assert
        Assert.NotNull(controller);
    }

    [Fact]
    public void Create_ShouldReturn_TemperatureConversionController()
    {
        // Arrange
        var factory = new TemperatureConverterControllerFactory();

        // Act
        var controller = factory.Create();

        // Assert
        Assert.IsType<TemperatureConversionController>(controller);
    }
}
