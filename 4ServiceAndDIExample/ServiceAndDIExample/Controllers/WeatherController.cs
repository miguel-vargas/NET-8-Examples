using Microsoft.AspNetCore.Mvc;
using ServiceAndDIExample.Models;
using ServiceAndDIExample.Services;

namespace ServiceAndDIExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    /*
     * NOTES: This is a class field that will hold the WeatherService
     * after it is injected via the constructor below.
     */
    private readonly WeatherService _weatherService;
    
    /*
     * NOTES: Since we registered the WeatherService in Startup.cs we
     * can use it throughout our application. This process of INJECTING
     * the service is called dependency injection. Our WeatherController
     * is dependent on the WeatherService to work.
     * 
     * This constructor is called by .NET and .NET also sees that it
     * requires a service that is registered in the service collection
     * and supplies it automatically!
     */
    public WeatherController(WeatherService weatherService)
    {
        // NOTES: Here we assign the service supplied to us by .NET to the local field.
        _weatherService = weatherService;
    }
    
    // GET: api/<weather>
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        /*
         * NOTES: Comparing this project to the last we can see an advantage
         * of using services is having LEAN controllers. We strive to have
         * as little logic as possible in a controller as its responsibility
         * should only be to handle request by passing them off to services
         * and returning the results from the services back to the requester.
         */
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