using TemperaturConverter.ConsoleCLient.UI;
using TemperaturConverter.ConsoleCLient.Interfaces;

namespace TemperaturConverter.ConsoleCLient.Factories;

public class UserInteractionFactory  
{
    public IUserInteraction Create() => new UserInteraction();
}
