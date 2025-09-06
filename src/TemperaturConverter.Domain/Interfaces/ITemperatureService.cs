
namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureService
{
    public double Convert(ITemperatureUnit from, ITemperatureUnit to, double value);
}
