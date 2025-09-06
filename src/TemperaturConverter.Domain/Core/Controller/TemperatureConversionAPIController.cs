using TemperaturConverter.Domain.Interfaces;

namespace TemperaturConverter.Domain.Core;

public class TemperatureConversionAPIController
{
    private readonly ITemperatureService _service;
    private readonly ITemperatureValidator _validator;
    private readonly ITemperatureUnitRepository _repository;

    public TemperatureConversionAPIController(
        ITemperatureService service, 
        ITemperatureValidator validator,
        ITemperatureUnitRepository repository)
    {
        _service = service;
        _validator = validator;
        _repository = repository;
    }

    public void Convert()
    {
        //try
        //{
        //    //var fromUnit = 
        //    //var toUnit = 
        //    //var value = 

        //    //var result = _service.Convert(fromUnit, toUnit, value);
        //}
    }
}