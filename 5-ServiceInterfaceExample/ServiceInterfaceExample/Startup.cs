using ServiceInterfaceExample.Interfaces;
using ServiceInterfaceExample.Services;

namespace ServiceInterfaceExample;

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

        /*
         * NOTES: This is how we register a service and tie it to its interface.
         * This is useful for future planning. If ever there was a new shiny toy
         * .NET releases and you want to create a new implementation called
         * SuperWeatherService, you can simply switch it here and all the classes
         * that used the old implementation will now use the new one. A lot easier
         * than trying to find every place in code that used the old way and
         * manually replace them all.
         */
        services.AddSingleton<IWeatherService, WeatherService>();
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