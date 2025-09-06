using TemperaturConverter.UI;
using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Factories;

public class UserInteractionFactory  
{
    public IUserInteraction Create() => new UserInteraction();
}
