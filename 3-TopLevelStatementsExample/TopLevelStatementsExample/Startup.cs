/*
 * NOTES: We are able to declare namespaces for all types in a file
 * ONCE and save spacing. We no longer need brackets between the entire
 * file and indenting everything by one tab. (Results in cleaner and
 * clearer code)
 *
 * IMPORTANT: ONLY available with C# 10 and above. (.NET 6 uses C# 10)
 */ 

namespace TopLevelStatementsExample;

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