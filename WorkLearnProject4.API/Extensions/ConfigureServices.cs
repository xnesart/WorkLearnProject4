namespace WorkLearnProject4.API.Extensions;

public static class ConfigureServices
{
    public static void ConfigureApiServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddControllers();
        services.ConfigureDataBase(configurationManager);
    }
}