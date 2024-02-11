using MultiServiceAndQueryExample.Core.Models;

namespace MultiServiceAndQueryExample.Core.Interfaces;

public interface IWeatherService
{
    public IEnumerable<WeatherForecast> GetWeatherForecasts();

    public WeatherForecast GetWeatherForecastById(int id);

    public string CreateWeatherForecast(string value);

    public string UpdateWeatherForecast(int id, string value);

    public string DeleteWeatherForecast(int id);
}