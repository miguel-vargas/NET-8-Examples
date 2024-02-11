namespace Intro;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }

    public override string ToString()
    {
        return $"For the date {Date} we are showing the temperature at {TemperatureC}º Celsius.\n" +
               $"For those in the U.S. that means it will be {TemperatureF}º Fahrenheit.\n" +
               $"And finally a one word summary from our chief meteorologist...{Summary}\n";
    }
}