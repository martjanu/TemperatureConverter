using TemperaturConverter.ConsoleCLient.Validators;

namespace TemperaturConverter.ConsoleClient.Tests.Validators;

public class TemperatureValidatorTests
{
    private readonly TemperatureValidator _validator;

    public TemperatureValidatorTests()
    {
        _validator = new TemperatureValidator();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    public void TryParseTemperature_ShouldReturnNull_ForNullOrWhitespace(string input)
    {
        var result = _validator.TryParseTemperature(input);
        Assert.Null(result);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("123abc")]
    [InlineData("!@#")]
    public void TryParseTemperature_ShouldReturnNull_ForInvalidNumbers(string input)
    {
        var result = _validator.TryParseTemperature(input);
        Assert.Null(result);
    }

    [Theory]
    [InlineData("0", 0)]
    [InlineData("123", 123)]
    [InlineData("-45", -45)]
    [InlineData("3.1415", 3.1415)]
    [InlineData("+10.5", 10.5)]
    public void TryParseTemperature_ShouldReturnDouble_ForValidNumbers(string input, double expected)
    {
        var result = _validator.TryParseTemperature(input);
        Assert.NotNull(result);
        Assert.Equal(expected, result.Value, 5); // 5 skaitmenų tikslumas double palyginimui
    }
}
