using TemperaturConverter.Domain.Interfaces;

namespace TemperatureConverter.UI;

public class ConsoleAction : IInteraction
{
    public string ReadInput()
    {
        Console.Write("> ");
        return Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
    }

    public void WriteOutput(string message)
    {
        Console.WriteLine(message);
    }
}
