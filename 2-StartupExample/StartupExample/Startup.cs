namespace StartupExample;

/*
 * NOTES: Startup.cs is another file that was typically used to configure
 * our WebAPIs. It allows Program.cs to be concerned with running the app
 * and Startup is just concerned with configuring the app at "startup".
 */
public class Startup
{
    private IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    /*
     * NOTES: This method will take care of adding services to our service
     * collection.
     */
    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddAuthorization();
        
        services.AddControllers();
    
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    /*
     * NOTES: This method will take care of telling the app to use the
     * services we want.
     */
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