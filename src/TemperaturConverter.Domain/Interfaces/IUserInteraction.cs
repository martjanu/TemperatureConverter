
namespace TemperaturConverter.Domain.Interfaces;

public interface IUserInteraction
{
    public  string ReadInput();
    public  void WriteOutput(string message);
}
