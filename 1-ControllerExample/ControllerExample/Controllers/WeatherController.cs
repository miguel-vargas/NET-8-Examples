using ControllerExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controllers
{
    /*
     * NOTES: This is a WebAPI controller in .NET and it inherits a lot of its functionality
     * from ControllerBase. The syntax to extend a class is "<your-class-name> : <class-to-extend>
     */
    
    // NOTES: Here we are using a route attribute to denote that this controller can be hit at
    // the endpoint "{{baseURL}}/api/[controller name]". Notice we can use a special template,
    // in this case [controller] is replaced at runtime by the name of the class minus controller.
    // so WeatherController becomes "/weather". This is useful so we do not hard code a route to a
    // name that we later change, for example we update WeatherController to WeatherForecastController
    // [controller] will take care of the route automatically so it then becomes "/weatherforecast"
    [Route("api/[controller]")]
    [ApiController] // NOTES: this attribute also helps .NET to identify a controller.
    public class WeatherController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];
        
        // GET: api/<weather>
        [HttpGet] // NOTES: This attribute denotes this is a GET
        public IEnumerable<WeatherForecast> Get()
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
        
        // GET api/<weather>/5
        [HttpGet("{id}")] // NOTES: This attribute denotes this is a GET and takes in an ID in the route
        public WeatherForecast Get(int id)
        {
            return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }
        
        // POST api/<weather>
        [HttpPost] // NOTES: This attribute denotes this is a POST
        // NOTES: The FromBody here tells .NET that "value" is in the body of the request
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<weather>/5
        [HttpPut("{id}")] // NOTES: This attribute denotes this is a PUT with ID in the route.
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<weather>/5
        [HttpDelete("{id}")] // NOTES: This attribute denotes this is a DELETE with ID in the route.
        public void Delete(int id)
        {
        }
    }
}
