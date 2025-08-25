using System;
using System.Collections.Generic;
using Xunit;
using TemperaturConverter.Domain.Models;

namespace TemperatureConverter.Tests.Domain.Models;

public class CelsiusUnitTests
{
    private readonly CelsiusUnit _sut;

    public CelsiusUnitTests()
    {
        _sut = new CelsiusUnit();
    }

    public static IEnumerable<object[]> ToKelvinData =>
        new List<object[]>
        {
            new object[] { 0m, 273.15m },
            new object[] { 100m, 373.15m },
            new object[] { -273.15m, 0m },
            new object[] { -100m, 173.15m },
            new object[] { 25.5m, 298.65m }
        };

    [Theory]
    [MemberData(nameof(ToKelvinData))]
    public void ToKelvin_ShouldConvertCorrectly(decimal input, decimal expected)
    {
        var result = _sut.ToKelvin(input);
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> FromKelvinData =>
        new List<object[]>
        {
            new object[] { 273.15m, 0m },
            new object[] { 373.15m, 100m },
            new object[] { 0m, -273.15m },
            new object[] { 173.15m, -100m },
            new object[] { 298.65m, 25.5m }
        };

    [Theory]
    [MemberData(nameof(FromKelvinData))]
    public void FromKelvin_ShouldConvertCorrectly(decimal input, decimal expected)
    {
        var result = _sut.FromKelvin(input);
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> RoundTripData =>
        new List<object[]>
        {
            new object[] { -100m },
            new object[] { 0m },
            new object[] { 36.6m },
            new object[] { 1000m },
            new object[] { 273.15m }
        };

    [Theory]
    [MemberData(nameof(RoundTripData))]
    public void RoundTripConversion_ShouldReturnOriginalValue(decimal input)
    {
        var kelvin = _sut.ToKelvin(input);
        var back = _sut.FromKelvin(kelvin);
        Assert.Equal(input, back, 6); // 6 skaitmenų tikslumas
    }
}
