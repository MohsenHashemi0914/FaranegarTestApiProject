using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Contracts.City;
using WeatherInformationOfCities.Api.Infrastructure.Logging;

namespace WeatherInformationOfCities.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        #region Constructor

        private readonly ICityApplication _cityApplication;

        public CityController(ICityApplication cityApplication)
        {
            _cityApplication = cityApplication;
        }

        #endregion

        [HttpGet("GetByName")]
        public CityViewModel GetByName([FromQuery] CitySearchModel query)
        {
            var result = _cityApplication.Search(query);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(CityController),
                "Request successful", null, result);

            return result;
        }

        [HttpGet("GetList")]
        public List<CityViewModel> GetList()
        {
            var result = _cityApplication.GetList();
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(CityController),
                "Request successful", null, result);

            return result;
        }

        [HttpPut("Edit")]
        public OperationResult Edit(EditCity command)
        {
            var result = _cityApplication.Edit(command);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(CityController),
                "Request successful", null, result.Message);

            return result;

        }

        [HttpPost("Add")]
        public OperationResult Add(AddCity command)
        {
            var result = _cityApplication.Add(command);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(CityController),
                "Request successful", null, result.Message);

            return result;
        }

        [HttpDelete("Delete")]
        public OperationResult Delete(ushort id)
        {
            var result = _cityApplication.Delete(id);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(CityController),
                "Request successful", null, result.Message);

            return result;
        }

        [HttpPatch("Restore")]
        public OperationResult Restore(ushort id)
        {
            var result = _cityApplication.Restore(id);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(CityController),
                "Request successful", null, result.Message);

            return result;
        }
    }
}
