using TemperaturConverter.UI;
using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Tests.UI;

public class UserInteractionTests
{
    [Fact]
    public void ReadInput_ShouldReturn_TrimmedLowerCaseString()
    {
        // Arrange
        var input = "  HeLLo  ";
        var expected = "hello";

        var originalIn = Console.In;
        Console.SetIn(new StringReader(input + Environment.NewLine));

        var interaction = new UserInteraction();

        try
        {
            // Act
            var result = interaction.ReadInput();

            // Assert
            Assert.Equal(expected, result);
        }
        finally
        {
            Console.SetIn(originalIn); 
        }
    }

    [Fact]
    public void ReadInput_ShouldReturn_EmptyString_WhenNoInput()
    {
        // Arrange
        var originalIn = Console.In;
        Console.SetIn(new StringReader(Environment.NewLine));

        var interaction = new UserInteraction();

        try
        {
            // Act
            var result = interaction.ReadInput();

            // Assert
            Assert.Equal(string.Empty, result);
        }
        finally
        {
            Console.SetIn(originalIn);
        }
    }

    [Fact]
    public void WriteOutput_ShouldWriteMessageToConsole()
    {
        // Arrange
        var message = "Test message";
        var originalOut = Console.Out;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var interaction = new UserInteraction();

        try
        {
            // Act
            interaction.WriteOutput(message);

            // Assert
            var output = stringWriter.ToString().Trim();
            Assert.Equal(message, output);
        }
        finally
        {
            Console.SetOut(originalOut); 
        }
    }

    [Fact]
    public void UserInteraction_ShouldImplement_IUserInteraction()
    {
        // Arrange & Act
        var interaction = new UserInteraction();

        // Assert
        Assert.IsAssignableFrom<IUserInteraction>(interaction);
    }
}
