using Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Application.Contracts.Weather
{
    public class AddWeather
    {
        [Range(1, ushort.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public ushort CityId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string GeneralCondition { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string CurrentTemperature { get; set; }
    }
}
