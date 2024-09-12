using Microsoft.AspNetCore.Mvc;
using Serilog;
using WorkLearnProject4.Data.Models;
using WorkLearnProject4.Data.Repository;

namespace WorkLearnProject4.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : Controller
{
    public IWeatherRepository WeatherRepository { get; private set; }
    private readonly Serilog.ILogger _logger = Log.ForContext<WeatherController>();

    public WeatherController(IWeatherRepository weatherRepository)
    {
        WeatherRepository = weatherRepository;
    }

    [HttpGet]
    public ActionResult<CurrentWeather> GetCurrentWeather()
    {
        _logger.Information("Getting current weather");

        return Ok(WeatherRepository.GetCurrentWeather());
    }

    [HttpGet("{id}")]
    public ActionResult<CurrentWeather> GetWeatherById(Guid id)
    {
        _logger.Information($"Getting weather by {id}");

        return Ok(WeatherRepository.GetById(id));
    }

    [HttpPost]
    public ActionResult AddWeather(CurrentWeather weather)
    {
        _logger.Information($"Adding weather with parameters {weather}");

        WeatherRepository.Add(weather);
        
        return Ok();
    }

    [HttpPut]
    public ActionResult UpdateWeather(CurrentWeather weather)
    {
        _logger.Information($"Updating weather with parameters {weather}");

        WeatherRepository.Put(weather);
        return Ok();
    }

    [HttpPatch]
    public ActionResult PatchWeather(CurrentWeather weather)
    {
        _logger.Information($"Patching weather with parameters {weather}");
        WeatherRepository.Patch(weather);
        
        return Ok();
    }

    [HttpDelete]
    public ActionResult DeleteWeather(Guid id)
    {
        _logger.Information($"Deleting weather with id {id}");

        WeatherRepository.Delete(id);
        
        return Ok();
    }
}