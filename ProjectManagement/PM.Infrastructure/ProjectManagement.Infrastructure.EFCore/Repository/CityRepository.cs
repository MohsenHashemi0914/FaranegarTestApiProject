using Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Contracts.City;
using ProjectManagement.Domain.CityAgg;

namespace ProjectManagement.Infrastructure.EFCore.Repository
{
    public class CityRepository : BaseRepository<ushort, City>, ICityRepository
    {
        #region Constructor

        private readonly ProjectContext _context;

        public CityRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        public EditCity GetDetailsBy(ushort id)
        {
            return _context.Cities
                .Where(x => !x.IsDeleted)
                .Select(x => new EditCity
                {
                    Id = x.Id,
                    Name = x.Name,
                    Position = x.Position
                }).FirstOrDefault(x => x.Id == id);
        }

        public List<CityViewModel> GetList()
        {
            return _context.Cities
                .Include(x => x.Province)
                .Include(x => x.Weather)
                .Select(x => new CityViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Scope = x.Scope,
                    State = x.IsDeleted ? "حدف شده" : "حدف نشده",
                    Position = x.Position,
                    Province = x.Province.Name,
                    CreationDate = x.CreationDate.ToFarsi(),
                    CurrentTemperature = x.Weather.CurrentTemperature
                }).AsNoTracking()
            .OrderByDescending(x => x.Id).ToList();
        }

        public CityViewModel Search(CitySearchModel search)
        {
            return _context.Cities
                .Where(x => !x.IsDeleted)
                .Include(x => x.Province)
                .Include(x => x.Weather)
                .Select(x => new CityViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Scope = x.Scope,
                    State = x.IsDeleted ? "حدف شده" : "حدف نشده",
                    Position = x.Position,
                    Province = x.Province.Name,
                    CurrentTemperature = x.Weather.CurrentTemperature,
                    CreationDate = x.CreationDate.ToFarsi()
                }).AsNoTracking()
            .FirstOrDefault(x => x.Name == search.Name);
        }
    }
}
