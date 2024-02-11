namespace Intro;

class Program
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    
    // NOTES: The main method, this will run at the start of our app.
    // For some reason Rider is not opening console apps so instead
    // we can use the dotnet CLI in the terminal. Simply navigate to
    // the project's folder (not the solution, one level deeper, the
    // project) and type "dotnet run"
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Orlando!");
        
        Console.WriteLine("Our list of summaries include:");

        foreach (var summary in Summaries)
        {
            Console.WriteLine("- " + summary);
        }
        
        var forecast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
        
        Console.WriteLine("Tomorrow's Forecast is as follows:\n");
        Console.WriteLine(forecast.ToString());
        
        Console.WriteLine("Goodbye!!\n");
    }
}