using Moq;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Repositories;

namespace TemperaturConverter.DOmain.Tests.Repositories;

public class TemperatureUnitRepositoryTests
{
    private readonly Dictionary<string, ITemperatureUnit> _dict;
    private readonly TemperatureUnitRepository _repo;
    private readonly Mock<ITemperatureUnit> _mockUnit1;
    private readonly Mock<ITemperatureUnit> _mockUnit2;

    public TemperatureUnitRepositoryTests()
    {
        _dict = new Dictionary<string, ITemperatureUnit>();
        _repo = new TemperatureUnitRepository(_dict);

        _mockUnit1 = new Mock<ITemperatureUnit>();
        _mockUnit2 = new Mock<ITemperatureUnit>();
    }

    [Fact]
    public void GetUnit_ShouldReturnNull_WhenUnitNotRegistered()
    {
        // Act
        var result = _repo.GetUnit("Celsius");

        // Assert
        Assert.Null(result);
    }

    [Theory]
    [InlineData("celsius")]
    [InlineData("CELSIUS")]
    [InlineData("CeLsIuS")]
    public void GetUnit_ShouldReturnUnit_WhenUnitExists_IgnoringCase(string inputName)
    {
        // Arrange
        _dict["celsius"] = _mockUnit1.Object;

        // Act
        var result = _repo.GetUnit(inputName);

        // Assert
        Assert.NotNull(result);
        Assert.Same(_mockUnit1.Object, result);
    }

    [Fact]
    public void GetListOfUnitNames_ShouldReturnMessage_WhenNoUnitsRegistered()
    {
        // Act
        var result = _repo.GetListOfUnitNames();

        // Assert
        Assert.Equal("No temperature units registered.", result);
    }

    [Fact]
    public void GetListOfUnitNames_ShouldReturnSortedListOfUnits()
    {
        // Arrange
        _dict["kelvin"] = _mockUnit1.Object;
        _dict["celsius"] = _mockUnit2.Object;

        // Act
        var result = _repo.GetListOfUnitNames();

        // Assert
        var expected =
@"- celsius
- kelvin
";
        Assert.Equal(expected, result);
    }
}
