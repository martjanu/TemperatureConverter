using TemperaturConverter.Factories;
using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.UI;

namespace TemperaturConverter.Tests.Factories;

public class UserInteractionFactoryTests
{
    [Fact]
    public void Create_ShouldReturn_NotNull()
    {
        // Arrange
        var factory = new UserInteractionFactory();

        // Act
        var result = factory.Create();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Create_ShouldReturn_IUserInteraction()
    {
        // Arrange
        var factory = new UserInteractionFactory();

        // Act
        var result = factory.Create();

        // Assert
        Assert.IsAssignableFrom<IUserInteraction>(result);
    }

    [Fact]
    public void Create_ShouldReturn_UserInteractionInstance()
    {
        // Arrange
        var factory = new UserInteractionFactory();

        // Act
        var result = factory.Create();

        // Assert
        Assert.IsType<UserInteraction>(result);
    }
}
