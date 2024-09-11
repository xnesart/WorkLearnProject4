using Microsoft.AspNetCore.Mvc;
using WorkLearnProject4.Data.Models;
using WorkLearnProject4.Data.Repository;

namespace WorkLearnProject4.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : Controller
{
    public IRepository<CurrentWeather> WeatherCtx { get; private set; }

    public WeatherController(IRepository<CurrentWeather> weatherCtx)
    {
        WeatherCtx = weatherCtx;
    }

    [HttpGet]
    public IEnumerable<Customer> GetCurrentWeather()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetWeatherById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult<Customer> AddWeather(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult<Customer> UpdateWeather(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public ActionResult<Customer> DeleteWeather(Guid id)
    {
        throw new NotImplementedException();
    }
}