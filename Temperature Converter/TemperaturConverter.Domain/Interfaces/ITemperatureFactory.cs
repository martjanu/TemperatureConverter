namespace TemperaturConverter.Domain.Interfaces;

public interface ITemperatureFactory
{
    static abstract IClientInteraction CreateInteraction();
    static abstract ITemperatureRepository CreateRepository(Dictionary<string, ITemperatureUnit> units);
    static abstract ITemperatureService CreateService();
    static abstract ITemperatureValidator CreateValidator();
}