using MultiServiceAndQueryExample.Core.Interfaces;
using MultiServiceAndQueryExample.Core.Services;

namespace MultiServiceAndQueryExample;

public class Startup
{
    private IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddAuthorization();
        
        services.AddControllers();
    
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSingleton<IWeatherService, WeatherService>();
        // NOTES: We are registering another service to our service collection.
        services.AddSingleton<ILocationService, LocationService>();
    }

    public void Configure(WebApplication app, IHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();
    }
}