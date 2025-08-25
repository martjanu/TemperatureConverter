
namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureService
{
    public decimal Convert(ITemperatureUnit from, ITemperatureUnit to, decimal value);
}
