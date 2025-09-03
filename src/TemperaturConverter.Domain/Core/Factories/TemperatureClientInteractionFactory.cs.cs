using TemperaturConverter.Domain.Interfaces;
using TemperaturConverter.Domain.Core.UI;

namespace TemperaturConverter.Domain.Core.Factories;

public class UserInteractionFactory
{
    public IUserInteraction Create() => new ConsoleAction();
}
