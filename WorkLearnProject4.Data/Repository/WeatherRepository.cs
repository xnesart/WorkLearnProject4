using Serilog;
using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public class WeatherRepository : IWeatherRepository
{
    private LearnBdContext _context;
    private readonly ILogger _logger = Log.ForContext<WeatherRepository>();

    public WeatherRepository(LearnBdContext context)
    {
        _context = context;
    }

    public void Add(CurrentWeather weather)
    {
        weather.Id = Guid.NewGuid();
        _logger.Information($"Adding weather with parameters {weather} in repository method");
        _context.Weathers.Add(weather);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        _logger.Information($"Deleting weather with id {id} in repository method");

        var foundWeather = _context.Weathers.FirstOrDefault(e => e.Id == id);
        if (foundWeather == null)
        {
            _logger.Error($"Error ,Weather with id {id} not found");
            throw new KeyNotFoundException($"Error ,Weather with id {id} not found");
        }

        _context.Weathers.Remove(foundWeather);
        _context.SaveChanges();
    }

    public void Put(CurrentWeather weather)
    {
        _logger.Information($"Updating weather with parameters {weather} in repository method");

        var foundWeather = _context.Weathers.FirstOrDefault(e => e.Id == weather.Id);
        if (foundWeather == null)
        {
            _logger.Error($"Error, weather with id {weather.Id} not found");
            throw new KeyNotFoundException("Error, weather are not found");
        }

        _context.Entry(foundWeather).CurrentValues.SetValues(weather);
        _context.SaveChanges();
    }

    public void Patch(CurrentWeather weather)
    {
        _logger.Information($"Patching weather in repository method with id {weather.Id}");

        var foundWeather = _context.Weathers.FirstOrDefault(w => w.Id == weather.Id);
        if (foundWeather == null)
        {
            _logger.Error($"Weather with id {weather.Id} not found");
            throw new KeyNotFoundException($"Weather with id {weather.Id} not found");
        }

        if (weather.Date != default) foundWeather.Date = weather.Date;
        if (weather.MaxTemp != default) foundWeather.MaxTemp = weather.MaxTemp;
        if (weather.MinTemp != default) foundWeather.MinTemp = weather.MinTemp;
        if (weather.Temp != default) foundWeather.Temp = weather.Temp;
        if (!string.IsNullOrEmpty(weather.Status)) foundWeather.Status = weather.Status;

        _context.SaveChanges();
    }

    public CurrentWeather GetById(Guid id)
    {
        _logger.Information($"Getting weather by id {id} in repository method");

        var weather = _context.Weathers.FirstOrDefault(e => e.Id == id);
        if (weather == null)
        {
            _logger.Error($"Error, weather by id {id} not found");
        }

        return weather;
    }

    public CurrentWeather GetCurrentWeather()
    {
        _logger.Information("Getting current weather in repository method");
        var currentWeather = _context.Weathers.OrderByDescending(cw => cw.Date).FirstOrDefault();

        if (currentWeather == null)
        {
            _logger.Error("Weather are not found in repository method");
            throw new KeyNotFoundException("Weather are not found");
        }

        return currentWeather;
    }
}