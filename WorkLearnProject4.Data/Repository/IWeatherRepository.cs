using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public interface IWeatherRepository
{
    void Add(CurrentWeather weather);
    void Delete(Guid id);
    void Put(CurrentWeather weather);
    void Patch(CurrentWeather weather);
    CurrentWeather GetById(Guid id);
    CurrentWeather GetCurrentWeather();
}