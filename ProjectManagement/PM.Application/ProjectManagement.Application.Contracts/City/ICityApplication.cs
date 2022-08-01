using Framework.Application;

namespace ProjectManagement.Application.Contracts.City
{
    public interface ICityApplication
    {
        OperationResult Add(AddCity command);
        OperationResult Edit(EditCity command);
        EditCity GetDetailsBy(ushort id);
        OperationResult Delete(ushort id);
        OperationResult Restore(ushort id);
        CityViewModel Search(CitySearchModel search);
        List<CityViewModel> GetList();
    }
}
