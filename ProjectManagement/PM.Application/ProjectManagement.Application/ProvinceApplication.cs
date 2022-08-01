using Framework.Application;
using ProjectManagement.Application.Contracts.Province;
using ProjectManagement.Domain.ProvinceAgg;

namespace ProjectManagement.Application
{
    public class ProvinceApplication : IProvinceApplication
    {
        #region Constructor

        private readonly IProvinceRepository _provinceRepository;

        public ProvinceApplication(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        #endregion

        public OperationResult Add(AddProvince command)
        {
            var operation = new OperationResult();
            if (_provinceRepository.IsExist(x => x.Name.ToLower() == command.Name.ToLower()))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var province = new Province(command.Name, command.Position, command.Scope);
            _provinceRepository.Add(province);
            _provinceRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Delete(ushort id)
        {
            var operation = new OperationResult();

            var province = _provinceRepository.GetBy(id);
            if (province is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            province.Delete();
            _provinceRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Edit(EditProvince command)
        {
            var operation = new OperationResult();

            if (_provinceRepository.IsExist(x => x.Name.ToLower() == command.Name.ToLower() && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var province = _provinceRepository.GetBy(command.Id);
            if (province is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            province.Edit(command.Name, command.Position, command.Scope);
            _provinceRepository.SaveChanges();

            return operation.Succeeded();
        }

        public EditProvince GetDetailsBy(ushort id)
        {
            return _provinceRepository.GetDetailsBy(id);
        }

        public List<ProvinceViewModel> GetList()
        {
            return _provinceRepository.GetList();
        }

        public OperationResult Restore(ushort id)
        {
            var operation = new OperationResult();

            var province = _provinceRepository.GetBy(id);
            if (province is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            province.Restore();
            _provinceRepository.SaveChanges();

            return operation.Succeeded();
        }

        public ProvinceViewModel Search(ProvinceSearchModel search)
        {
            return _provinceRepository.Search(search);
        }
    }
}
