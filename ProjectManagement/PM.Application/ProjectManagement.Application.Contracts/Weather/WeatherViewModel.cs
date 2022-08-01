namespace ProjectManagement.Application.Contracts.Weather
{
    public class WeatherViewModel
    {
        public ushort Id { get; set; }
        public ushort CityId { get; set; }
        public string CreationDate { get; set; }
        public string GeneralCondition { get; set; }
        public string CurrentTemperature { get; set; }
    }
}
