using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ProjectManagement.Application.Contracts.Province;
using WeatherInformationOfCities.Api.Infrastructure.Logging;

namespace WeatherInformationOfCities.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinceController : ControllerBase
    {
        #region Constructor

        private readonly IProvinceApplication _provinceApplication;

        public ProvinceController(IProvinceApplication provinceApplication)
        {
            _provinceApplication = provinceApplication;
        }

        #endregion

        [HttpGet("GetByName")]
        public ProvinceViewModel GetByName([FromQuery] ProvinceSearchModel query)
        {
            var result = _provinceApplication.Search(query);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(ProvinceController),
                "Request successful", null, result);

            return result;
        }

        [HttpGet("GetList")]
        public List<ProvinceViewModel> GetList()
        {
            var result = _provinceApplication.GetList();
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(ProvinceController),
                "Request successful", null, result);

            return result;
        }

        [HttpPut("Edit")]
        public OperationResult Edit(EditProvince command)
        {
            var result = _provinceApplication.Edit(command);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(ProvinceController),
                "Request successful", null, result.Message);

            return result;
        }

        [HttpPost("Add")]
        public OperationResult Add(AddProvince command)
        {
            var result = _provinceApplication.Add(command);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(ProvinceController),
                "Request successful", null, result.Message);

            return result;
        }

        [HttpDelete("Delete")]
        public OperationResult Delete(byte id)
        {
            var result = _provinceApplication.Delete(id);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(ProvinceController),
                "Request successful", null, result.Message);

            return result;
        }

        [HttpPatch("Restore")]
        public OperationResult Restore(byte id)
        {
            var result = _provinceApplication.Restore(id);
            LoggerProxy.Log(Framework.Logging.LogLevels.Info, typeof(ProvinceController),
                "Request successful", null, result.Message);

            return result;
        }
    }
}
