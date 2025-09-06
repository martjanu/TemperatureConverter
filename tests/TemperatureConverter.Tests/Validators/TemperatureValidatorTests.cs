using TemperaturConverter.Domain.Validators;

namespace TemperaturConverter.Tests.Validators;

public class TemperatureValidatorTests
{
    [Theory]
    [InlineData("100", 100)]
    [InlineData("0", 0)]
    [InlineData("-273.15", -273.15)]
    [InlineData("  36.6  ", 36.6)]
    public void TryParseTemperature_ShouldReturn_ParsedDouble_WhenValidInput(string input, double expected)
    {
        // Arrange
        var validator = new TemperatureValidator();

        // Act
        var result = validator.TryParseTemperature(input);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("abc")]
    [InlineData("100C")]
    public void TryParseTemperature_ShouldReturn_Null_WhenInvalidInput(string input)
    {
        // Arrange
        var validator = new TemperatureValidator();

        // Act
        var result = validator.TryParseTemperature(input);

        // Assert
        Assert.Null(result);
    }
}
