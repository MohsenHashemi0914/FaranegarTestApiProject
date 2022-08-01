using Framework.Application;
using ProjectManagement.Application.Contracts.Weather;
using ProjectManagement.Domain.WeatherAgg;

namespace ProjectManagement.Application
{
    public class WeatherApplication : IWeatherApplication
    {
        #region Constructor

        private readonly IWeatherRepository _weatherRepository;

        public WeatherApplication(IWeatherRepository WeatherRepository)
        {
            _weatherRepository = WeatherRepository;
        }

        #endregion

        public OperationResult Add(AddWeather command)
        {
            var operation = new OperationResult();
            if (_weatherRepository.IsExist(x => x.CityId == command.CityId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var weather = new Weather(command.GeneralCondition, command.CurrentTemperature, command.CityId);
            _weatherRepository.Add(weather);
            _weatherRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Edit(EditWeather command)
        {
            var operation = new OperationResult();
            var weather = _weatherRepository.GetBy(command.Id);
            if (weather is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            weather.Edit(command.GeneralCondition, command.CurrentTemperature);
            _weatherRepository.SaveChanges();

            return operation.Succeeded();
        }

        public WeatherViewModel GetWeatherOfCityBy(ushort cityId)
        {
            return _weatherRepository.GetWeatherOfCityBy(cityId);
        }
    }
}