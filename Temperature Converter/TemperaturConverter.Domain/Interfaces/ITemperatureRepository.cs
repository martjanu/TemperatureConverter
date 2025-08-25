
namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureRepository
{
    public ITemperatureUnit? GetTemperatureUnit(string name);
}
