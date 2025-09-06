using TemperaturConverter.Domain.Core.Factories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Validators;

namespace TemperaturConverter.Tests.Factories;

public class TemperatureValidatorFactoryTests
{
    [Fact]
    public void Create_ShouldReturn_NotNull()
    {
        // Arrange
        var factory = new TemperatureValidatorFactory();

        // Act
        var validator = factory.Create();

        // Assert
        Assert.NotNull(validator);
    }

    [Fact]
    public void Create_ShouldReturn_ITemperatureValidator()
    {
        // Arrange
        var factory = new TemperatureValidatorFactory();

        // Act
        var validator = factory.Create();

        // Assert
        Assert.IsAssignableFrom<ITemperatureValidator>(validator);
    }

    [Fact]
    public void Create_ShouldReturn_TemperatureValidatorInstance()
    {
        // Arrange
        var factory = new TemperatureValidatorFactory();

        // Act
        var validator = factory.Create();

        // Assert
        Assert.IsType<TemperatureValidator>(validator);
    }
}
