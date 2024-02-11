using MultiServiceAndQueryExample.Core.Interfaces;
using MultiServiceAndQueryExample.Core.Models;

namespace MultiServiceAndQueryExample.Core.Services;

public class LocationService : ILocationService
{
    private readonly IWeatherService _weatherService;
    
    /*
     * NOTES: Here again we see the power of having a service collection.
     * We do not need to handle creating/injecting the service ourselves.
     * We simply configured it once during Startup and can use the service
     * anywhere we require it.
     */
    public LocationService(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    
    private static readonly string[] LocationNames =
    [
        "Orlando", "Miami", "New York City", "Boise", "Seoul", "Hong Kong", "Rome", "Kansas City", "San Francisco", "Belfast"
    ];
    
    public IEnumerable<Location> GetLocations(bool includeWeather = false)
    {
        return LocationNames.Select(name => CreateLocation(name, includeWeather)).ToArray();
    }
    
    /*
     * NOTES: The id parameter will represent the index of LocationNames. We want
     * to return null if the id is outside the index range (out of bounds).
     */
    public Location? GetLocationById(int id, bool includeWeather = false)
    {
        /*
         * NOTES: C# is also a zero-based index language so even if in this case 10
         * is passed in, our last element is at LocationNames[9]. 10 is out of bounds. 
         */
        if (id < 0 || id >= LocationNames.Length)
        {
            return null;
        }

        return CreateLocation(LocationNames[id], includeWeather);
    }
        
    public string CreateLocation(string value)
    {
        return $"Created a location for {value}!";
    }

    public string UpdateLocation(int id, string value)
    {
        return $"Updated a location for {id} with {value}!";
    }
    
    public string DeleteLocation(int id)
    {
        return $"Deleted a location with id = {id}!";
    }

    /*
     * NOTES: Here is a helper function to create a location class. We only want
     * this service to have access to this method so we mark it as private.
     *
     * If we want to include the weather with this location we call the weather
     * service to grab the current weather!
     */
    private Location CreateLocation(string name, bool includeWeather)
    {
        var location = new Location { Name = name };

        if (includeWeather)
        {
            location.CurrentWeather = _weatherService.GetWeatherForecastById(0);
        }

        return location;
    }
}