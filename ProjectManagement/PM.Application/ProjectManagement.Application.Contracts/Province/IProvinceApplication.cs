using Framework.Application;

namespace ProjectManagement.Application.Contracts.Province
{
    public interface IProvinceApplication
    {
        OperationResult Add(AddProvince command);
        OperationResult Edit(EditProvince command);
        EditProvince GetDetailsBy(ushort id);
        OperationResult Delete(ushort id);
        OperationResult Restore(ushort id);
        ProvinceViewModel Search(ProvinceSearchModel search);
        List<ProvinceViewModel> GetList();
    }
}
