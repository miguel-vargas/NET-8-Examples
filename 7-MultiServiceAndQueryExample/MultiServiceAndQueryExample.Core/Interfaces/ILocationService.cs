using MultiServiceAndQueryExample.Core.Models;

namespace MultiServiceAndQueryExample.Core.Interfaces;

public interface ILocationService
{
    /*
     * NOTES: We have introduce a new primitive type as a parameter.
     * booleans are known as bool in C#. We are also defaulting the
     * value to false in case it is not passed in.
     */
    public IEnumerable<Location> GetLocations(bool includeWeather = false);

    /*
     * NOTES: The return type here is Location followed by a question mark.
     * This means that the return type is nullable, meaning we can either
     * return a location or null.
     */
    public Location? GetLocationById(int id, bool includeWeather = false);

    public string CreateLocation(string value);

    public string UpdateLocation(int id, string value);

    public string DeleteLocation(int id);
}