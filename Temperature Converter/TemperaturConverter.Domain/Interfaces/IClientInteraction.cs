
namespace TemperaturConverter.Domain.Interfaces;

public interface IClientInteraction
{
    public  string ReadInput();
    public  void WriteOutput(string message);
}
