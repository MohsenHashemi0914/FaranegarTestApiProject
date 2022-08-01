using Framework.Application;

namespace ProjectManagement.Application.Contracts.Weather
{
    public interface IWeatherApplication
    {
        OperationResult Add(AddWeather command);
        OperationResult Edit(EditWeather command);
        WeatherViewModel GetWeatherOfCityBy(ushort cityId);
    }
}
