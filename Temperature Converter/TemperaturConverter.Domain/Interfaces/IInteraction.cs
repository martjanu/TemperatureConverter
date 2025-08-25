
namespace TemperaturConverter.Domain.Interfaces;

public interface IInteraction
{
    public  string ReadInput();
    public  void WriteOutput(string message);
}
