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

    /// <summary>
    /// Getting current weather
    /// </summary>
    /// <returns>Last added weather
    ///<response code = "200">Returns the last added weather</response>
    ///<response code = "404"> is not found</response>
    /// </returns>
    [HttpGet]
    public ActionResult<CurrentWeather> GetCurrentWeather()
    {
        _logger.Information("Getting current weather");

        return Ok(WeatherRepository.GetCurrentWeather());
    }

    /// <summary>
    /// Getting weather by id
    /// </summary>
    /// <param name="id">Weather id</param>
    /// <returns>Weather by id
    ///<response code = "200">Returns the weather with current id</response>
    ///<response code = "404">Weather with this id not found</response>
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<CurrentWeather> GetWeatherById(Guid id)
    {
        _logger.Information($"Getting weather by {id}");

        return Ok(WeatherRepository.GetById(id));
    }
    
    /// <summary>
    /// Get weather by id from query
    /// </summary>
    /// <param name="id"></param>
    /// <returns> Weather by id
    ///<response code = "200">Returns the weather with current id</response>
    ///<response code = "404">Weather with this id not found</response>
    /// </returns>
    [HttpGet("search")]
    public ActionResult<CurrentWeather> GetWeatherByQuery([FromQuery] Guid id)
    {
        _logger.Information($"Getting weather from query by {id}");

        return Ok(WeatherRepository.GetById(id));
    }

    /// <summary>
    /// Post new weather
    /// </summary>
    /// <param name="weather"></param>
    /// <returns>StatusCode success
    ///<response code = "200">Returns Ok</response>
    ///<response code = "400">Checking for null</response>
    ///<response code = "422">Some fields are invalid</response>
    /// </returns>
    [HttpPost]
    public ActionResult AddWeather(CurrentWeather weather)
    {
        _logger.Information($"Adding weather with parameters {weather}");

        WeatherRepository.Add(weather);

        return Ok();
    }

    /// <summary>
    /// Weather full update
    /// </summary>
    /// <param name="weather"></param>
    /// <returns>
    ///<response code = "200">Put is complete</response>
    ///<response code = "400">Checking for null</response>
    /// </returns>
    [HttpPut]
    public ActionResult UpdateWeather(CurrentWeather weather)
    {
        _logger.Information($"Updating weather with parameters {weather}");

        WeatherRepository.Put(weather);
        return Ok();
    }

    /// <summary>
    /// Patching weather
    /// </summary>
    /// <param name="weather"></param>
    /// <returns>
    ///<response code = "200">Patch is complete</response>
    ///<response code = "400">Checking for null</response>
    /// </returns>
    [HttpPatch]
    public ActionResult<CurrentWeather> PatchWeather(CurrentWeatherPatch weather)
    {
        _logger.Information($"Patching weather with parameters {weather}");

        return Ok(WeatherRepository.Patch(weather));
    }
    
    /// <summary>
    /// Delete weather by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    ///<response code = "200">Deleting successfully</response>
    ///<response code = "404"> is not found</response>
    /// </returns>
    [HttpDelete]
    public ActionResult DeleteWeather(Guid id)
    {
        _logger.Information($"Deleting weather with id {id}");

        WeatherRepository.Delete(id);

        return Ok();
    }
}