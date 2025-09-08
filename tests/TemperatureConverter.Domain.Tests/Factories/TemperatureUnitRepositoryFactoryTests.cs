using TemperaturConverter.Domain.Factories;
using TemperaturConverter.Domain.Repositories;
using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Tests.Factories;

public class TemperatureUnitRepositoryFactoryTests
{
    private readonly TemperatureUnitRepositoryFactory _factory;
    private readonly ITemperatureUnitRepository _repository;

    public TemperatureUnitRepositoryFactoryTests()
    {
        _factory = new TemperatureUnitRepositoryFactory();
        _repository = _factory.Create();
    }

    [Fact]
    public void Create_ShouldReturnNonNullRepository()
    {
        var result = _factory.Create();
        Assert.NotNull(result);
    }

    [Fact]
    public void Create_ShouldReturnTemperatureUnitRepositoryType()
    {
        var result = _factory.Create();
        Assert.IsType<TemperatureUnitRepository>(result);
    }

    [Fact]
    public void Repository_ShouldContainAllExpectedUnits()
    {
        Assert.NotNull(_repository.GetUnit("celsius"));
        Assert.NotNull(_repository.GetUnit("fahrenheit"));
        Assert.NotNull(_repository.GetUnit("kelvin"));
        Assert.NotNull(_repository.GetUnit("bananas"));
    }

    [Theory]
    [InlineData("Celsius")]
    [InlineData("FAHRENHEIT")]
    [InlineData("kElViN")]
    [InlineData("Bananas")]
    public void GetUnit_ShouldBeCaseInsensitive(string name)
    {
        var unit = _repository.GetUnit(name);
        Assert.NotNull(unit);
    }
}
