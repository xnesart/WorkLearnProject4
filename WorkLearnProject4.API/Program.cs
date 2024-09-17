using Serilog;
using WorkLearnProject4.API.Configuration;
using WorkLearnProject4.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureApiServices(builder.Configuration);

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "My API";
    config.Version = "v1";
});
builder.Host.UseSerilog();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseOpenApi();
    app.UseSwaggerUi(); 
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
