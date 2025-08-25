using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;
using TemperaturConverter.Application.Repositories;

namespace TemperatureConverter.Tests.Application;

public class TemperatureUnitRepositoryTests
{
    [Fact]
    public void GetTemperatureUnit_ReturnsUnit_WhenUnitExists()
    {
        // Arrange
        var fahrenheit = new FahrenheitUnit();
        var units = new Dictionary<string, ITemperatureUnit>
        {
            { fahrenheit.Name, fahrenheit }
        };
        var repository = new TemperatureUnitRepository(units);

        // Act
        var result = repository.GetTemperatureUnit("Fahrenheit");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fahrenheit, result);
    }

    [Fact]
    public void GetTemperatureUnit_ReturnsNull_WhenUnitDoesNotExist()
    {
        // Arrange
        var repository = new TemperatureUnitRepository(new Dictionary<string, ITemperatureUnit>());

        // Act
        var result = repository.GetTemperatureUnit("Celsius");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Constructor_AllowsNullDictionary_AndCreatesEmptyRepository()
    {
        // Arrange
        Dictionary<string, ITemperatureUnit>? units = null;

        // Act
        var repository = new TemperatureUnitRepository(units);
        var result = repository.GetTemperatureUnit("AnyUnit");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetTemperatureUnit_IsCaseInsensitive()
    {
        // Arrange
        var fahrenheit = new FahrenheitUnit();
        var units = new Dictionary<string, ITemperatureUnit>(StringComparer.OrdinalIgnoreCase)
        {
            { fahrenheit.Name, fahrenheit }
        };
        var repository = new TemperatureUnitRepository(units);

        // Act
        var result = repository.GetTemperatureUnit("fahrenheit"); // mažosiomis

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fahrenheit, result);
    }

}
