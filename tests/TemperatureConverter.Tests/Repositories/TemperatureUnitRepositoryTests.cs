using TemperaturConverter.Domain.Core.Repositories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;

namespace TemperaturConverter.Tests.Repositories;

public class TemperatureUnitRepositoryTests
{
    [Fact]
    public void GetUnit_ShouldReturn_CorrectUnit_WhenExists()
    {
        // Arrange
        var units = new Dictionary<string, ITemperatureUnit>
        {
            ["celsius"] = new CelsiusUnit(),
            ["fahrenheit"] = new FahrenheitUnit()
        };
        var repository = new TemperatureUnitRepository(units);

        // Act
        var result = repository.GetUnit("celsius");

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CelsiusUnit>(result);
    }

    [Fact]
    public void GetUnit_ShouldReturn_Null_WhenUnitDoesNotExist()
    {
        // Arrange
        var repository = new TemperatureUnitRepository(null);

        // Act
        var result = repository.GetUnit("kelvin");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetUnitNames_ShouldReturn_RegisteredUnits()
    {
        // Arrange
        var units = new Dictionary<string, ITemperatureUnit>
        {
            ["celsius"] = new CelsiusUnit(),
            ["fahrenheit"] = new FahrenheitUnit()
        };
        var repository = new TemperatureUnitRepository(units);

        // Act
        var result = repository.GetUnitNames();

        // Assert
        Assert.Contains("celsius", result);
        Assert.Contains("fahrenheit", result);
    }

    [Fact]
    public void GetUnitNames_ShouldReturn_Message_WhenNoUnitsRegistered()
    {
        // Arrange
        var repository = new TemperatureUnitRepository(null);

        // Act
        var result = repository.GetUnitNames();

        // Assert
        Assert.Equal("No temperature units registered.", result);
    }

    [Fact]
    public void GetUnit_ShouldBeCaseInsensitive()
    {
        // Arrange
        var units = new Dictionary<string, ITemperatureUnit>
        {
            ["celsius"] = new CelsiusUnit()
        };
        var repository = new TemperatureUnitRepository(units);

        // Act
        var resultLower = repository.GetUnit("celsius");
        var resultUpper = repository.GetUnit("CELSIUS");

        // Assert
        Assert.NotNull(resultLower);
        Assert.NotNull(resultUpper);
        Assert.IsType<CelsiusUnit>(resultLower);
        Assert.IsType<CelsiusUnit>(resultUpper);
    }
}
