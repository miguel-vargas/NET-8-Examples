using StartupExample.Models;

namespace StartupExample;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var startup = new Startup(builder.Configuration);
        
        // Add services to the container.
        startup.ConfigureServices(builder.Services);

        var app = builder.Build();
        
        // Use services added above
        startup.Configure(app, app.Environment);

        app.Run();
    }
}