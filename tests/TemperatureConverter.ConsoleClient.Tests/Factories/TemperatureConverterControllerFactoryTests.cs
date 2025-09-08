using Moq;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Repositories;
using TemperaturConverter.ConsoleCLient.Interfaces;
using TemperatureConverter.ConsoleCLient.Controllers;
using TemperaturConverter.ConsoleCLient.Factories;

namespace TemperaturConverter.ConsoleCLient.Tests.Factories;

public class TemperatureConverterControllerFactoryTests
{
    private readonly Mock<ITemperatureService> _mockService;
    private readonly Mock<ITemperatureValidator> _mockValidator;
    private readonly Mock<IUserInteraction> _mockInteraction;
    private readonly Mock<ITemperatureUnitRepository> _mockRepository;

    private readonly TemperatureConverterControllerFactory _factory;
    private readonly TemperatureConversionController _instance1;
    private readonly TemperatureConversionController _instance2;

    public TemperatureConverterControllerFactoryTests()
    {
        _mockService = new Mock<ITemperatureService>();
        _mockValidator = new Mock<ITemperatureValidator>();
        _mockInteraction = new Mock<IUserInteraction>();
        _mockRepository = new Mock<ITemperatureUnitRepository>();

        _factory = new TemperatureConverterControllerFactory(
            _mockService.Object,
            _mockValidator.Object,
            _mockInteraction.Object,
            _mockRepository.Object
        );

        _instance1 = _factory.Create();
        _instance2 = _factory.Create();
    }

    [Fact]
    public void Create_ShouldReturnNonNullInstance()
    {
        var result = _factory.Create();
        Assert.NotNull(result);
    }

    [Fact]
    public void Create_ShouldReturnNewInstanceEachTime()
    {
        Assert.NotSame(_instance1, _instance2);
    }
}
