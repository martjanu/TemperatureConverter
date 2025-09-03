using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Core.UI;

public class ConsoleAction : IUserInteraction
{
    public string ReadInput()
    {
        Console.Write("> ");
        return Console.ReadLine()?.Trim().ToLowerInvariant() ?? string.Empty;
    }

    public void WriteOutput(string message) => Console.WriteLine(message);
}
