/*
 * NOTES: Here we see that we import System and a lot of its libraries.
 * As we expand this project, we will be using some of the types over
 * and over again. We will have to declare these same usings all over our
 * project(s). This got tiring so in C# 10 implicit usings allows us to omit
 * a lot of this. Makes it easier to not have 50+ lines of usings at the top
 * of every file.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NoImplicitUsingsExample.Models;

namespace NoImplicitUsingsExample.Controllers;

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