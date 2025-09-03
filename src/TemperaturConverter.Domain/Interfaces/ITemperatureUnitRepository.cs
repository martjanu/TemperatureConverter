
namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureUnitRepository
{
    public ITemperatureUnit? GetTemperatureUnit(string name);
    public string GetUnitNames();
}
