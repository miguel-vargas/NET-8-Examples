using ServiceInterfaceExample.Models;

namespace ServiceInterfaceExample.Interfaces;

/*
 * NOTES: This is an interface. It "describes" what a class will look like. A
 * class that IMPLEMENTS an interface must have implementation details for each
 * method defined in the interface. In this case that means our WeatherService
 * that will implement this interface will have the 5 methods, along with its
 * return type (output), and PARAMETERS (inputs). It can have more methods of
 * its own but it MUST implement these.
 *
 * CONVENTION: Prefix the interface's name with a capital I
 */
public interface IWeatherService
{
    public IEnumerable<WeatherForecast> GetWeatherForecasts();

    public WeatherForecast GetWeatherForecastById(int id);

    public string CreateWeatherForecast(string value);

    public string UpdateWeatherForecast(int id, string value);

    public string DeleteWeatherForecast(int id);
}