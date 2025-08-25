using TemperaturConverter.Application.Services;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Models;

namespace TemperaturConverter.Tests.Application;

public class TemperatureUnitServiceTests
{
    [Fact]
    public void Convert_FahrenheitToFahrenheit_ReturnsSameValue()
    {
        // Arrange
        var service = new TemperatureUnitService();
        ITemperatureUnit fahrenheit = new FahrenheitUnit();
        decimal value = 100m;

        // Act
        var result = service.Convert(fahrenheit, fahrenheit, value);

        // Assert
        Assert.Equal(value, result);
    }

    [Fact]
    public void Convert_FahrenheitToCelsius_ReturnsCorrectValue()
    {
        // Arrange
        var service = new TemperatureUnitService();
        ITemperatureUnit fahrenheit = new FahrenheitUnit();
        ITemperatureUnit celsius = new CelsiusUnit();
        decimal value = 212m;

        // Act
        var result = service.Convert(fahrenheit, celsius, value);

        // Assert
        Assert.Equal(100m, decimal.Round(result, 0));
    }

    [Fact]
    public void Convert_CelsiusToFahrenheit_ReturnsCorrectValue()
    {
        // Arrange
        var service = new TemperatureUnitService();
        ITemperatureUnit fahrenheit = new FahrenheitUnit();
        ITemperatureUnit celsius = new CelsiusUnit();
        decimal value = 0m;

        // Act
        var result = service.Convert(celsius, fahrenheit, value);

        // Assert
        Assert.Equal(32m, decimal.Round(result, 0));
    }

    [Fact]
    public void Convert_UsingMockUnits_ReturnsExpectedValue()
    {
        // Arrange
        var service = new TemperatureUnitService();

        var fromMock = new MockTemperatureUnit(
            toKelvin: x => x + 10,
            fromKelvin: x => x - 10
        );
        var toMock = new MockTemperatureUnit(
            toKelvin: x => x * 2,
            fromKelvin: x => x / 2
        );

        decimal value = 5m;

        // Act
        var result = service.Convert(fromMock, toMock, value);

        // Assert
        Assert.Equal(7.5m, result);
    }
}

// Paprasta mock klasė testams
public class MockTemperatureUnit : ITemperatureUnit
{
    private readonly Func<decimal, decimal> _toKelvin;
    private readonly Func<decimal, decimal> _fromKelvin;

    public MockTemperatureUnit(Func<decimal, decimal> toKelvin, Func<decimal, decimal> fromKelvin)
    {
        _toKelvin = toKelvin;
        _fromKelvin = fromKelvin;
    }

    public string Name => "MockUnit";

    public decimal ToKelvin(decimal value) => _toKelvin(value);
    public decimal FromKelvin(decimal value) => _fromKelvin(value);
}
