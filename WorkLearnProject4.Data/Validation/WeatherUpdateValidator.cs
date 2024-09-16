using FluentValidation;
using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Validation;

public class WeatherUpdateValidator:AbstractValidator<CurrentWeather>
{
    public WeatherUpdateValidator()
    {
        RuleFor(y => y.MinTemp).NotEmpty().NotNull();
        RuleFor(y=>y.MaxTemp).NotNull().NotEmpty();
        RuleFor(y=>y.Temp).NotNull().NotEmpty();
        RuleFor(y=>y.Status).NotNull().NotEmpty();
        RuleFor(y=>y.Date).NotNull().NotEmpty();
    }
}