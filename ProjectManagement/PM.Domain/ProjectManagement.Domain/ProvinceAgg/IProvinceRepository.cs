using Framework.Domain;
using ProjectManagement.Application.Contracts.Province;

namespace ProjectManagement.Domain.ProvinceAgg
{
    public interface IProvinceRepository : IRepository<ushort, Province>
    {
        EditProvince GetDetailsBy(ushort id);
        ProvinceViewModel Search(ProvinceSearchModel search);
        List<ProvinceViewModel> GetList();
    }
}
