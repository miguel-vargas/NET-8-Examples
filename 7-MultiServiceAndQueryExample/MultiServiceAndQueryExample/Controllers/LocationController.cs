using Microsoft.AspNetCore.Mvc;
using MultiServiceAndQueryExample.Core.Interfaces;
using MultiServiceAndQueryExample.Core.Models;

namespace MultiServiceAndQueryExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;
    
    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }
    
    /*
     * NOTES: We are using a new attribute [FromQuery] to specify that the includeWeather
     * parameter will come from the request's query parameters. That's the parameters found
     * at the end of a URL after the ?. If there are multiple query parameters they are
     * separated by &.
     */
    // GET: api/<location>?includeWeather=false
    [HttpGet]
    public IEnumerable<Location> Get([FromQuery] bool includeWeather = false)
    {
        return _locationService.GetLocations(includeWeather);
    }
    
    /*
     * NOTES: We have not done this in past projects, but here we are being specific that
     * the id is in the route using the [FromRoute] attribute.
     *
     * We also change the return type to ActionResult that allows us to use some included
     * responses with .NET like Ok (200) with the response in the body and NotFound (404)
     * with a message in the response.
     */
    // GET api/<location>/5?includeWeather=false
    [HttpGet("{id}")]
    public ActionResult<Location> Get([FromRoute]int id, [FromQuery] bool includeWeather = false)
    {
        var location = _locationService.GetLocationById(id, includeWeather);

        if (location == null)
        {
            return NotFound($"Location with id = {id} was not found.");
        }
        
        return Ok(location);
    }
        
    // POST api/<location>
    [HttpPost]
    public string Post([FromBody] string value)
    {
        return _locationService.CreateLocation(value);
    }

    // PUT api/<location>/5
    [HttpPut("{id}")]
    public string Put(int id, [FromBody] string value)
    {
        return _locationService.UpdateLocation(id, value);
    }

    // DELETE api/<location>/5
    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return _locationService.DeleteLocation(id);
    }
}