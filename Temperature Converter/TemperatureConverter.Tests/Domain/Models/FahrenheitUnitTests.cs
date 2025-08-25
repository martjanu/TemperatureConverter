using TemperaturConverter.Domain.Models;
using Xunit;

namespace TemperatureConverter.Tests.Domain.Models;

public class FahrenheitUnitTests
{
    private readonly FahrenheitUnit _sut = new FahrenheitUnit();

    [Theory]
    [InlineData(32, 273.15)]
    [InlineData(212, 373.15)]
    [InlineData(0, 255.372222)]
    [InlineData(-40, 233.15)]
    public void ToKelvin_ShouldConvertCorrectly(decimal fahrenheit, decimal expectedKelvin)
    {
        var result = _sut.ToKelvin(fahrenheit);
        Assert.Equal(expectedKelvin, result, 6); // tikslumas iki 6 skaitmenų
    }

    [Theory]
    [InlineData(273.15, 32)]
    [InlineData(373.15, 212)]
    [InlineData(255.372222, 0)]
    [InlineData(233.15, -40)]
    public void FromKelvin_ShouldConvertCorrectly(decimal kelvin, decimal expectedFahrenheit)
    {
        var result = _sut.FromKelvin(kelvin);
        Assert.Equal(expectedFahrenheit, result, 6);
    }

    [Theory]
    [InlineData(32)]
    [InlineData(212)]
    [InlineData(0)]
    [InlineData(-40)]
    [InlineData(100)]
    public void RoundTripConversion_ShouldReturnOriginalValue(decimal fahrenheit)
    {
        var kelvin = _sut.ToKelvin(fahrenheit);
        var back = _sut.FromKelvin(kelvin);
        Assert.Equal(fahrenheit, back, 6);
    }
}
