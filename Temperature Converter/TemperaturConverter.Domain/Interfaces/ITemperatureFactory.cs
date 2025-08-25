namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureFactory
{
    static abstract IInteraction CreateInteraction();
    static abstract ITemperatureUnitRepository CreateRepository(Dictionary<string, ITemperatureUnit> units);
    static abstract ITemperatureService CreateService();
    static abstract IValidator CreateValidator();
}