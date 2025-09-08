using Moq;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Services;

namespace TemperaturConverter.Domain.Tests.Services;

public class TemperatureServiceTests
{
    private readonly TemperatureService _service;
    private readonly Mock<ITemperatureUnit> _fromUnit;
    private readonly Mock<ITemperatureUnit> _toUnit;

    public TemperatureServiceTests()
    {
        _service = new TemperatureService();
        _fromUnit = new Mock<ITemperatureUnit>();
        _toUnit = new Mock<ITemperatureUnit>();
    }

    [Fact]
    public void Convert_ShouldThrowArgumentNullException_WhenFromUnitIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            _service.Convert(null!, _toUnit.Object, 100));
    }

    [Fact]
    public void Convert_ShouldThrowArgumentNullException_WhenToUnitIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            _service.Convert(_fromUnit.Object, null!, 100));
    }

    [Fact]
    public void Convert_ShouldReturnExpectedResult_WhenUnitsAreMocked()
    {
        // Arrange
        double input = 123;
        double kelvinValue = 456;
        double expected = 789;

        _fromUnit
            .Setup(f => f.ToKelvin(input))
            .Returns(kelvinValue);

        _toUnit
            .Setup(t => t.FromKelvin(kelvinValue))
            .Returns(expected);

        // Act
        var result = _service.Convert(_fromUnit.Object, _toUnit.Object, input);

        // Assert (1) result
        Assert.Equal(expected, result);

        // Assert (2) side effects – nėra

        // Assert (3) calls
        _fromUnit.Verify(f => f.ToKelvin(input), Times.Once);
        _toUnit.Verify(t => t.FromKelvin(kelvinValue), Times.Once);
    }
}
