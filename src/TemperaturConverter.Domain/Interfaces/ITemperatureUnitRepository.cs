
namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureUnitRepository
{
    public ITemperatureUnit? GetUnit(string name);
    public string GetListOfUnitNames();
}
