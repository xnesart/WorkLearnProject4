using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WorkLearnProject4.Data;

namespace WorkLearnProject4.API.Extensions;

public static class DataBaseExtensions
{
    public static void ConfigureDataBase(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        var connectionString = configurationManager.GetConnectionString("DefaultConnection");
        services.AddDbContext<LearnBdContext>(options => options.UseSqlServer(connectionString));
    }
}