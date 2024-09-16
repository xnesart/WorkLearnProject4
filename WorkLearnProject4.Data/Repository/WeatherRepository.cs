using FluentValidation;
using Serilog;
using WorkLearnProject4.Core.Exceptions;
using WorkLearnProject4.Data.Models;
using WorkLearnProject4.Data.Validation;

namespace WorkLearnProject4.Data.Repository;

public class WeatherRepository : IWeatherRepository
{
    private LearnBdContext _context;
    private readonly ILogger _logger = Log.ForContext<WeatherRepository>();
    private readonly IValidator<CurrentWeather> _validator;

    public WeatherRepository(LearnBdContext context,IValidator<CurrentWeather> validator)
    {
        _context = context;
        _validator = validator;
    }

    public void Add(CurrentWeather weather)
    {
        var validationResult = _validator.Validate(weather);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new CustomValidationException($"Validation failed: {errorMessages}");
        }
        
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

    public CurrentWeather Patch(CurrentWeatherPatch weather)
    {
        _logger.Information($"Start patching weather with this parameters {weather} in repository method");

        var existingWeather = _context.Weathers.Find(weather.Id);

        if (existingWeather == null)
        {
            _logger.Error($"Error, Weather with id {weather.Id} not found");
            throw new ArgumentException($"Weather with id {weather.Id} not found.");
        }

        if (weather.Status != null) existingWeather.Status = weather.Status;
        if (weather.Temp.HasValue) existingWeather.Temp = weather.Temp.Value;
        if (weather.MinTemp.HasValue) existingWeather.MinTemp = weather.MinTemp.Value;
        if (weather.MaxTemp.HasValue) existingWeather.MaxTemp = weather.MaxTemp.Value;
        if (weather.Date.HasValue) existingWeather.Date = weather.Date.Value;

        _context.SaveChanges();

        foreach (var property in _context.Entry(existingWeather).Properties)
        {
            if (property.IsModified)
            {
                _logger.Information($"Property {property.Metadata.Name} was modified.");
            }
        }

        return existingWeather;
    }

    public CurrentWeather GetById(Guid id)
    {
        _logger.Information($"Getting weather by id {id} in repository method");

        var weather = _context.Weathers.FirstOrDefault(e => e.Id == id);
        if (weather == null)
        {
            _logger.Error($"Error, weather by id {id} not found");

            throw new NotFoundException($"Error, weather with id {id} not found");
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