using Framework.Domain;
using ProjectManagement.Domain.ProvinceAgg;
using ProjectManagement.Domain.WeatherAgg;

namespace ProjectManagement.Domain.CityAgg
{
    public class City : BasePlaceEntity<ushort>
    {
        public ushort ProvinceId { get; private set; }
        public Province Province { get; private set; }
        public Weather Weather { get; private set; }

        public City(string name, string position,
            ushort scope, ushort provinceId, ushort id = 0) : base(name, position, scope) // i toke id in here for adding seed data
        {
            ProvinceId = provinceId;
            if (id is not 0)
                Id = id;
        }

        protected City() : base("", "", default(ushort))
        {
        }

        public void Edit(string name, string position, ushort scope)
        {
            Name = name;
            Scope = scope;
            Position = position;
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
