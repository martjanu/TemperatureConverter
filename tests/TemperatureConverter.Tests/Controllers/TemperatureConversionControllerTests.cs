using Moq;
using TemperaturConverter.Domain.Interfaces;
using TemperatureConverter.Controllers;

namespace TemperaturConverter.Tests.Controllers;

public class TemperatureConversionControllerTests
{
    [Fact]
    public void Convert_ShouldCallInteractionWriteOutput_ForResult()
    {
        // Arrange
        var mockService = new Mock<ITemperatureService>();
        var mockValidator = new Mock<ITemperatureValidator>();
        var mockInteraction = new Mock<IUserInteraction>();
        var mockRepository = new Mock<ITemperatureUnitRepository>();

        mockRepository.Setup(r => r.GetUnitNames()).Returns("celsius, fahrenheit");
        mockRepository.Setup(r => r.GetUnit("celsius")).Returns(new Mock<ITemperatureUnit>().Object);
        mockRepository.Setup(r => r.GetUnit("fahrenheit")).Returns(new Mock<ITemperatureUnit>().Object);
        mockValidator.Setup(v => v.TryParseTemperature("100")).Returns(100);
        mockService.Setup(s => s.Convert(It.IsAny<ITemperatureUnit>(), It.IsAny<ITemperatureUnit>(), 100))
                   .Returns(212);

        mockInteraction.SetupSequence(i => i.ReadInput())
                       .Returns("celsius")
                       .Returns("fahrenheit")
                       .Returns("100");

        var controller = new TemperatureConversionController(
            mockService.Object,
            mockValidator.Object,
            mockInteraction.Object,
            mockRepository.Object
        );

        // Act
        controller.Convert();

        // Assert
        mockInteraction.Verify(i => i.WriteOutput(It.Is<string>(s => s.Contains("Result: 212"))), Times.Once);
    }

    [Fact]
    public void Convert_ShouldHandle_InvalidUnit_ThrowsArgumentException()
    {
        // Arrange
        var mockService = new Mock<ITemperatureService>();
        var mockValidator = new Mock<ITemperatureValidator>();
        var mockInteraction = new Mock<IUserInteraction>();
        var mockRepository = new Mock<ITemperatureUnitRepository>();

        mockRepository.Setup(r => r.GetUnitNames()).Returns("celsius, fahrenheit");
        mockRepository.Setup(r => r.GetUnit(It.IsAny<string>())).Returns<ITemperatureUnit>(null);

        mockInteraction.Setup(i => i.ReadInput()).Returns("invalidUnit");

        var controller = new TemperatureConversionController(
            mockService.Object,
            mockValidator.Object,
            mockInteraction.Object,
            mockRepository.Object
        );

        // Act
        controller.Convert();

        // Assert
        mockInteraction.Verify(i => i.WriteOutput(It.Is<string>(s => s.Contains("Input error: Invalid temperature unit provided."))), Times.Once);
    }

    [Fact]
    public void Convert_ShouldHandle_InvalidTemperatureValue()
    {
        // Arrange
        var mockService = new Mock<ITemperatureService>();
        var mockValidator = new Mock<ITemperatureValidator>();
        var mockInteraction = new Mock<IUserInteraction>();
        var mockRepository = new Mock<ITemperatureUnitRepository>();

        var mockUnit = new Mock<ITemperatureUnit>().Object;
        mockRepository.Setup(r => r.GetUnitNames()).Returns("celsius, fahrenheit");
        mockRepository.Setup(r => r.GetUnit("celsius")).Returns(mockUnit);
        mockRepository.Setup(r => r.GetUnit("fahrenheit")).Returns(mockUnit);
        mockValidator.Setup(v => v.TryParseTemperature("notANumber")).Returns((double?)null);

        mockInteraction.SetupSequence(i => i.ReadInput())
                       .Returns("celsius")
                       .Returns("fahrenheit")
                       .Returns("notANumber");

        var controller = new TemperatureConversionController(
            mockService.Object,
            mockValidator.Object,
            mockInteraction.Object,
            mockRepository.Object
        );

        // Act
        controller.Convert();

        // Assert
        mockInteraction.Verify(i => i.WriteOutput(It.Is<string>(s => s.Contains("Input error: Invalid temperature value provided."))), Times.Once);
    }
}
