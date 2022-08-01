using Framework.Domain;
using ProjectManagement.Application.Contracts.Weather;

namespace ProjectManagement.Domain.WeatherAgg
{
    public interface IWeatherRepository : IRepository<ushort, Weather>
    {
        WeatherViewModel GetWeatherOfCityBy(ushort cityId);
    }
}
