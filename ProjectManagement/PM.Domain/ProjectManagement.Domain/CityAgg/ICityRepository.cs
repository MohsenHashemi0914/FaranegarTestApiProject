using Framework.Domain;
using ProjectManagement.Application.Contracts.City;

namespace ProjectManagement.Domain.CityAgg
{
    public interface ICityRepository : IRepository<ushort, City>
    {
        EditCity GetDetailsBy(ushort id);
        CityViewModel Search(CitySearchModel search);
        List<CityViewModel> GetList();
    }
}
