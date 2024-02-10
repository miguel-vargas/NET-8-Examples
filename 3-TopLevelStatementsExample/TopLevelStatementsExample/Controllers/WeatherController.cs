using Microsoft.AspNetCore.Mvc;
using TopLevelStatementsExample.Models;

/*
 * NOTES: Compare file-level namespaces like in Startup.cs. Everything
 * in this file is indented by one tab and surrounded by brackets.
 */
namespace TopLevelStatementsExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];
        
        // GET: api/<weather>
        [HttpGet]
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
        [HttpGet("{id}")]
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
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<weather>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<weather>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
