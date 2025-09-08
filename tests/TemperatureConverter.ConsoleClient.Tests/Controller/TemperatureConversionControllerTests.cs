using Moq;
using TemperaturConverter.ConsoleCLient.Interfaces;
using TemperaturConverter.Domain.Interfaces;
using TemperatureConverter.ConsoleCLient.Controllers;
using Xunit;

public class TemperatureConversionControllerTests
{
    private readonly TemperatureConversionController _controller;
    private readonly Mock<ITemperatureService> _serviceMock;
    private readonly Mock<ITemperatureValidator> _validatorMock;
    private readonly Mock<IUserInteraction> _interactionMock;
    private readonly Mock<ITemperatureUnitRepository> _repositoryMock;

    private readonly Mock<ITemperatureUnit> _fromUnitMock;
    private readonly Mock<ITemperatureUnit> _toUnitMock;

    public TemperatureConversionControllerTests()
    {
        _serviceMock = new Mock<ITemperatureService>();
        _validatorMock = new Mock<ITemperatureValidator>();
        _interactionMock = new Mock<IUserInteraction>();
        _repositoryMock = new Mock<ITemperatureUnitRepository>();

        _controller = new TemperatureConversionController(
            _serviceMock.Object,
            _validatorMock.Object,
            _interactionMock.Object,
            _repositoryMock.Object
        );

        _fromUnitMock = new Mock<ITemperatureUnit>();
        _toUnitMock = new Mock<ITemperatureUnit>();
    }

    private void SetupValidUnits()
    {
        _repositoryMock.Setup(r => r.GetListOfUnitNames()).Returns("- Celsius\n- Fahrenheit\n");
        _repositoryMock.SetupSequence(r => r.GetUnit(It.IsAny<string>()))
            .Returns(_fromUnitMock.Object)
            .Returns(_toUnitMock.Object);
    }

    [Fact]
    public void Convert_InvalidUnit_ReturnsArgumentException()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetListOfUnitNames()).Returns("- celsius\n- fahrenheit\n");
        _repositoryMock.Setup(r => r.GetUnit(It.IsAny<string>())).Returns((ITemperatureUnit)null);
        _interactionMock.Setup(i => i.ReadInput()).Returns("UnknownUnit");

        // Act
        var ex = Record.Exception(() => _controller.Convert());

        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public void Convert_InvalidTemperature_ReturnsArgumentException()
    {
        // Arrange
        SetupValidUnits();

        _interactionMock.SetupSequence(i => i.ReadInput())
            .Returns("celsius")        
            .Returns("fahrenheit")     
            .Returns("abc");         

        _validatorMock.Setup(v => v.TryParseTemperature("abc")).Returns((double?)null);

        // Act
        var ex = Record.Exception(() => _controller.Convert());

        // Assert
        Assert.Null(ex);
    }
}
