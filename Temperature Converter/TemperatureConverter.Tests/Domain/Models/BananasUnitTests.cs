using System;
using System.Collections.Generic;
using Xunit;
using TemperaturConverter.Domain.Models;

namespace TemperatureConverter.Tests.Domain.Models;

public class BananasUnitTests
{
    private readonly BananasUnit _sut;

    public BananasUnitTests()
    {
        _sut = new BananasUnit();
    }

    public static IEnumerable<object[]> ToKelvinData =>
        new List<object[]>
        {
            new object[] { 0m, 0m },
            new object[] { 1m, 30m },
            new object[] { -1m, -30m },
            new object[] { 10m, 300m },
            new object[] { 2.5m, 75m }
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
            new object[] { 0m, 0m },
            new object[] { 30m, 1m },
            new object[] { -30m, -1m },
            new object[] { 300m, 10m },
            new object[] { 75m, 2.5m }
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
            new object[] { -1000m },
            new object[] { 0m },
            new object[] { 123.456m },
            new object[] { 999999m }
        };

    [Theory]
    [MemberData(nameof(RoundTripData))]
    public void RoundTripConversion_ShouldReturnOriginalValue(decimal input)
    {
        var kelvin = _sut.ToKelvin(input);
        var back = _sut.FromKelvin(kelvin);
        Assert.Equal(input, back, 6);
    }
}