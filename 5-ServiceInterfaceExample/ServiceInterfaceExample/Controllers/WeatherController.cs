using Microsoft.AspNetCore.Mvc;
using ServiceInterfaceExample.Interfaces;
using ServiceInterfaceExample.Models;

namespace ServiceInterfaceExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    /*
     * NOTES: Our class field's type can be more generic than
     * its concrete type. Interfaces are generic while the
     * classes that implement them are more concrete as they
     * have the actual details/logic of the class.
     */
    private readonly IWeatherService _weatherService;
    
    /*
     * NOTES: We can inject the interface and let .NET tie it to
     * whatever was registered in Startup.cs. Since the concrete
     * service was registered, we will be able to call its methods
     * just as if we only registered WeatherService like in the
     * last project.
     */
    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    
    // GET: api/<weather>
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return _weatherService.GetWeatherForecasts();
    }
        
    // GET api/<weather>/5
    [HttpGet("{id}")]
    public WeatherForecast Get(int id)
    {
        return _weatherService.GetWeatherForecastById(id);
    }
        
    // POST api/<weather>
    [HttpPost]
    public string Post([FromBody] string value)
    {
        return _weatherService.CreateWeatherForecast(value);
    }

    // PUT api/<weather>/5
    [HttpPut("{id}")]
    public string Put(int id, [FromBody] string value)
    {
        return _weatherService.UpdateWeatherForecast(id, value);
    }

    // DELETE api/<weather>/5
    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return _weatherService.DeleteWeatherForecast(id);
    }
}