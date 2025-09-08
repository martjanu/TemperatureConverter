using TemperaturConverter.ConsoleCLient.UI;

namespace TemperaturConverter.ConsoleCLient.Tests.UI;

public class UserInteractionTests
{
    [Fact]
    public void ReadInput_ShouldReturnTrimmedLowercaseValue()
    {
        // Arrange
        var input = "  Hello WORLD  ";
        var stringReader = new StringReader(input + Environment.NewLine);
        var originalIn = Console.In;
        Console.SetIn(stringReader);

        var ui = new UserInteraction();

        try
        {
            // Act
            var result = ui.ReadInput();

            // Assert
            Assert.Equal("hello world", result);
        }
        finally
        {
            Console.SetIn(originalIn); // atstatome pradinį įvesties srautą
        }
    }

    [Fact]
    public void ReadInput_ShouldReturnEmptyString_WhenNullIsRead()
    {
        var stringReader = new StringReader(string.Empty);
        var originalIn = Console.In;
        Console.SetIn(stringReader);

        var ui = new UserInteraction();

        try
        {
            var result = ui.ReadInput();
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
        var message = "Hello, User!";
        var stringWriter = new StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(stringWriter);

        var ui = new UserInteraction();

        try
        {
            ui.WriteOutput(message);
            var output = stringWriter.ToString().Trim();
            Assert.Equal(message, output);
        }
        finally
        {
            Console.SetOut(originalOut);  
        }
    }
}
