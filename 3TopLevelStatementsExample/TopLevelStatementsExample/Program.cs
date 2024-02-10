/* NOTES: We do not need to delare a namespace for a top level program.
 * It is added to a GLOBAL namespace by default. All using statements
 * must be at the top. Only one top level statement file may be used
 * per project. This is a way to avoid all the ceremony code to just
 * say "This is the main code".
 *
 * IMPORTANT: ONLY available with .NET 6 and above.
 */
using TopLevelStatementsExample;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
        
// Add services to the container.
startup.ConfigureServices(builder.Services);

var app = builder.Build();
        
// Use services added above
startup.Configure(app, app.Environment);

app.Run();