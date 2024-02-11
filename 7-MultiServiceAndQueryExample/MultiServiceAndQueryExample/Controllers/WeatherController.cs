using Microsoft.AspNetCore.Mvc;
using MultiServiceAndQueryExample.Core.Interfaces;
using MultiServiceAndQueryExample.Core.Models;

namespace MultiServiceAndQueryExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    
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