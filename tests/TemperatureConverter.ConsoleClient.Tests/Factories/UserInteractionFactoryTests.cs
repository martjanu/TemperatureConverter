using TemperaturConverter.ConsoleCLient.Factories;
using TemperaturConverter.ConsoleCLient.Interfaces;
 
namespace TemperaturConverter.ConsoleCLient.Tests.Factories;

public class UserInteractionFactoryTests
{
    private readonly UserInteractionFactory _factory;
    private readonly IUserInteraction _instance1;
    private readonly IUserInteraction _instance2;

    public UserInteractionFactoryTests()
    {
        _factory = new UserInteractionFactory();
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
