using Framework.Domain;
using ProjectManagement.Domain.CityAgg;

namespace ProjectManagement.Domain.ProvinceAgg
{
    public class Province : BasePlaceEntity<ushort>
    {
        public List<City> Cities { get; private set; }

        public Province(string name, string position, ushort scope, byte id = 0) // i toke id in here for adding seed data
            : base(name, position, scope)
        {
            Cities = new();
            if (id is not 0)
                Id = id;
        }

        protected Province() : base("", "", default(ushort))
        {
        }

        public void Edit(string name, string position, ushort scope)
        {
            Name = name;
            Position = position;
            Scope = scope;
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
