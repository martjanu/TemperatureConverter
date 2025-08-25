using System.IO;
using TemperatureConverter.UI;
using Xunit;

namespace TemperaturConverter.Tests.UI;

public class ConsoleActionTests
{
    [Fact]
    public void ReadInput_ReturnsTrimmedLowercaseString()
    {
        // Arrange
        var input = "  HeLLo WoRLD  ";
        var stringReader = new StringReader(input + Environment.NewLine);
        Console.SetIn(stringReader);
        var consoleAction = new ConsoleAction();

        // Act
        var result = consoleAction.ReadInput();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void ReadInput_ReturnsEmptyString_WhenInputIsNull()
    {
        // Arrange
        var stringReader = new StringReader(""); // Simulate empty input
        Console.SetIn(stringReader);
        var consoleAction = new ConsoleAction();

        // Act
        var result = consoleAction.ReadInput();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void WriteOutput_WritesMessageToConsole()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var consoleAction = new ConsoleAction();
        var message = "Test Message";

        // Act
        consoleAction.WriteOutput(message);
        var output = stringWriter.ToString().Trim(); // pašaliname \r\n

        // Assert
        Assert.Equal(message, output);
    }
}
