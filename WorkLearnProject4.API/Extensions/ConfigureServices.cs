using WorkLearnProject4.Data.Models;
using WorkLearnProject4.Data.Repository;

namespace WorkLearnProject4.API.Extensions;

public static class ConfigureServices
{
    public static void ConfigureApiServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddControllers();
        services.AddScoped<IRepository<Customer>, CustomerRepository>();
        services.AddScoped<IRepository<CurrentWeather>, WeatherRepository>();
        services.ConfigureDataBase(configurationManager);
    }
}