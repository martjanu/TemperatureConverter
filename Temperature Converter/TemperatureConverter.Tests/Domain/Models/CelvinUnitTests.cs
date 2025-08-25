using TemperaturConverter.Domain.Models;

namespace TemperatureConverter.Tests.Domain.Models;

public class CelvinUnitTests
{
    private readonly KelvinUnit _sut = new KelvinUnit();

    [Theory]
    [InlineData(0)]
    [InlineData(273.15)]
    [InlineData(-100)]
    [InlineData(1000)]
    public void ToKelvin_ShouldReturnSameValue(decimal input)
    {
        var result = _sut.ToKelvin(input);
        Assert.Equal(input, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(273.15)]
    [InlineData(-100)]
    [InlineData(1000)]
    public void FromKelvin_ShouldReturnSameValue(decimal input)
    {
        var result = _sut.FromKelvin(input);
        Assert.Equal(input, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(100)]
    [InlineData(-50)]
    [InlineData(500)]
    public void RoundTripConversion_ShouldReturnOriginalValue(decimal input)
    {
        var kelvin = _sut.ToKelvin(input);
        var back = _sut.FromKelvin(kelvin);
        Assert.Equal(input, back);
    }
}
