using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public class WeatherRepository:IRepository<CurrentWeather>
{
    public IEnumerable<CurrentWeather> All { get; }
    public void Add(CurrentWeather entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(CurrentWeather entity)
    {
        throw new NotImplementedException();
    }

    public void Update(CurrentWeather entity)
    {
        throw new NotImplementedException();
    }

    public CurrentWeather FindById(Guid id)
    {
        throw new NotImplementedException();
    }

    public CurrentWeather GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}