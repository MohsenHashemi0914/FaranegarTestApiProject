using Framework.Application;
using ProjectManagement.Application.Contracts.City;
using ProjectManagement.Domain.CityAgg;

namespace ProjectManagement.Application
{
    public class CityApplication : ICityApplication
    {
        #region Constructor

        private readonly ICityRepository _cityRepository;

        public CityApplication(ICityRepository CityRepository)
        {
            _cityRepository = CityRepository;
        }

        #endregion

        public OperationResult Add(AddCity command)
        {
            var operation = new OperationResult();
            if (_cityRepository.IsExist(x => x.Name.ToLower() == command.Name.ToLower()))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var city = new City(command.Name, command.Position, command.Scope, command.ProvinceId);
            _cityRepository.Add(city);
            _cityRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Delete(ushort id)
        {
            var operation = new OperationResult();

            var city = _cityRepository.GetBy(id);
            if (city is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            city.Delete();
            _cityRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Edit(EditCity command)
        {
            var operation = new OperationResult();

            if (_cityRepository.IsExist(x => x.Name.ToLower() == command.Name.ToLower() && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var city = _cityRepository.GetBy(command.Id);
            if (city is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            city.Edit(command.Name, command.Position, command.Scope);
            _cityRepository.SaveChanges();

            return operation.Succeeded();
        }

        public EditCity GetDetailsBy(ushort id)
        {
            return _cityRepository.GetDetailsBy(id);
        }

        public List<CityViewModel> GetList()
        {
            return _cityRepository.GetList();
        }

        public OperationResult Restore(ushort id)
        {
            var operation = new OperationResult();

            var city = _cityRepository.GetBy(id);
            if (city is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            city.Restore();
            _cityRepository.SaveChanges();

            return operation.Succeeded();
        }

        public CityViewModel Search(CitySearchModel search)
        {
            return _cityRepository.Search(search);
        }
    }
}