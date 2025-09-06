using TemperaturConverter.Domain.Core.Services;
using TemperaturConverter.Domain.Interfaces;
using Moq;

namespace TemperaturConverter.Tests.Services;

public class TemperatureServiceTests
{
    [Fact]
    public void Convert_ShouldThrowArgumentNullException_WhenFromUnitIsNull()
    {
        // Arrange
        var service = new TemperatureService();
        var mockToUnit = new Mock<ITemperatureUnit>();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => service.Convert(null!, mockToUnit.Object, 100));
    }

    [Fact]
    public void Convert_ShouldThrowArgumentNullException_WhenToUnitIsNull()
    {
        // Arrange
        var service = new TemperatureService();
        var mockFromUnit = new Mock<ITemperatureUnit>();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => service.Convert(mockFromUnit.Object, null!, 100));
    }

    [Fact]
    public void Convert_ShouldReturn_CorrectConvertedValue()
    {
        // Arrange
        var mockFromUnit = new Mock<ITemperatureUnit>();
        var mockToUnit = new Mock<ITemperatureUnit>();

        mockFromUnit.Setup(f => f.ToKelvin(100)).Returns(373.15);
        mockToUnit.Setup(t => t.FromKelvin(373.15)).Returns(212);

        var service = new TemperatureService();

        // Act
        var result = service.Convert(mockFromUnit.Object, mockToUnit.Object, 100);

        // Assert
        Assert.Equal(212, result);
    }

    [Fact]
    public void Convert_ShouldCall_ToKelvin_And_FromKelvin_Once()
    {
        // Arrange
        var mockFromUnit = new Mock<ITemperatureUnit>();
        var mockToUnit = new Mock<ITemperatureUnit>();

        mockFromUnit.Setup(f => f.ToKelvin(It.IsAny<double>())).Returns(0);
        mockToUnit.Setup(t => t.FromKelvin(It.IsAny<double>())).Returns(0);

        var service = new TemperatureService();

        // Act
        service.Convert(mockFromUnit.Object, mockToUnit.Object, 50);

        // Assert
        mockFromUnit.Verify(f => f.ToKelvin(50), Times.Once);
        mockToUnit.Verify(t => t.FromKelvin(0), Times.Once);
    }
}
