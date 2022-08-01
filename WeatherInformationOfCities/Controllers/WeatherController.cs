using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ProjectManagement.Application.Contracts.Weather;
using WeatherInformationOfCities.Api.Infrastructure.Logging;

namespace WeatherInformationOfCities.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        #region Constructor

        private readonly IWeatherApplication _weatherApplication;

        public WeatherController(IWeatherApplication WeatherApplication)
        {
            _weatherApplication = WeatherApplication;
        }

        #endregion

        [HttpGet("GetWeatherOfCityByCityId")]
        public WeatherViewModel GetWeatherOfCityBy([FromQuery] ushort cityId)
        {
            var result = _weatherApplication.GetWeatherOfCityBy(cityId);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(WeatherController),
                "Request successful", null, result);

            return result;
        }

        [HttpPost("AddWeatherForCity")]
        public OperationResult AddWeatherForCity([FromBody] AddWeather command)
        {
            var result = _weatherApplication.Add(command);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(WeatherController),
                "Request successful", null, result.Message);

            return result;
        }

        [HttpPut("EditWeatherOfCity")]
        public OperationResult EditWeatherOfCity(EditWeather command)
        {
            var result = _weatherApplication.Edit(command);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(WeatherController),
                "Request successful", null, result.Message);

            return result;
        }
    }
}
