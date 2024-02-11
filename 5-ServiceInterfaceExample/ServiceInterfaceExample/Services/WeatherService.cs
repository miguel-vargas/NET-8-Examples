using ServiceInterfaceExample.Interfaces;
using ServiceInterfaceExample.Models;

namespace ServiceInterfaceExample.Services;

/*
 * NOTES: To implement a service we use the syntax "<class> : <interface-to-implement>".
 * This is the same syntax for EXTENDS shown in an earlier project.
 */
public class WeatherService : IWeatherService
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    
    public IEnumerable<WeatherForecast> GetWeatherForecasts()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
            .ToArray();
        return forecast;
    }
        
    public WeatherForecast GetWeatherForecastById(int id)
    {
        return new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }
        
    public string CreateWeatherForecast(string value)
    {
        return $"Created a weather forecast for {value}!";
    }

    public string UpdateWeatherForecast(int id, string value)
    {
        return $"Updated a weather forecast for {id} with {value}!";
    }
    
    public string DeleteWeatherForecast(int id)
    {
        return $"Deleted a weather forecast with id = {id}!";
    }
}