using TemperaturConverter.ConsoleCLient.Interfaces;

namespace TemperaturConverter.ConsoleCLient.UI;

public class UserInteraction : IUserInteraction
{
    public string ReadInput()
    {
        Console.Write("> ");
        return Console.ReadLine()?.Trim().ToLowerInvariant() ?? string.Empty;
    }

    public void WriteOutput(string message) => Console.WriteLine(message);
}
