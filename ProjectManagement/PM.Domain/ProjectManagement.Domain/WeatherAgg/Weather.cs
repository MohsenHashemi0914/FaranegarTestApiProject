using Framework.Domain;
using ProjectManagement.Domain.CityAgg;

namespace ProjectManagement.Domain.WeatherAgg
{
    public class Weather : BaseEntity<ushort>
    {
        public string GeneralCondition { get; private set; }
        public string CurrentTemperature { get; private set; }
        public ushort CityId { get; private set; }
        public City City { get; private set; }

        public Weather(string generalCondition,
            string currentTemperature, ushort cityId, ushort id = 0) // i toke id in here for adding seed data
        {
            CityId = cityId;
            GeneralCondition = generalCondition;
            CurrentTemperature = currentTemperature;
            if (id is not 0)
                Id = id;
        }

        public void Edit(string generalCondition, string currentTemperature)
        {
            GeneralCondition = generalCondition;
            CurrentTemperature = currentTemperature;
        }

        protected Weather()
        {
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            if (IsDeleted)
                IsDeleted = false;
        }
    }
}
