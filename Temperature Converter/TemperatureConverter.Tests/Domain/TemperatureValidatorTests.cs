using System;
using TemperaturConverter.Domain.Validators;
using Xunit;

namespace TemperaturConverter.Tests.Validators;

public class TemperatureValidatorTests
{
    private readonly TemperatureValidator _validator;

    public TemperatureValidatorTests()
    {
        _validator = new TemperatureValidator();
    }

    [Theory]
    [InlineData("25.5", 25.5)]
    [InlineData("0", 0)]
    [InlineData("-10.75", -10.75)]
    [InlineData("100", 100)]
    public void TryParseTemperature_ValidInput_ReturnsDecimal(string input, decimal expected)
    {
        // Act
        var result = _validator.TryParseTemperature(input);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result.Value);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("")]
    [InlineData(null)]
    public void TryParseTemperature_InvalidInput_ReturnsNull(string input)
    {
        // Act
        var result = _validator.TryParseTemperature(input);

        // Assert
        Assert.Null(result);
    }
}
