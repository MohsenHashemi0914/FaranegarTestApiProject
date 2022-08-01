using Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Contracts.Province;
using ProjectManagement.Domain.ProvinceAgg;

namespace ProjectManagement.Infrastructure.EFCore.Repository
{
    public class ProvinceRepository : BaseRepository<ushort, Province>, IProvinceRepository
    {
        #region Constructor

        private readonly ProjectContext _context;

        public ProvinceRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        public EditProvince GetDetailsBy(ushort id)
        {
            return _context.Provinces
                .Where(x => !x.IsDeleted)
                .Select(x => new EditProvince
                {
                    Id = x.Id,
                    Name = x.Name,
                    Scope = x.Scope,
                    Position = x.Position,
                }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProvinceViewModel> GetList()
        {
            return _context.Provinces
                .Select(x => new ProvinceViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Scope = x.Scope,
                    State = x.IsDeleted ? "حدف شده" : "حدف نشده",
                    Position = x.Position,
                    CreationDate = x.CreationDate.ToFarsi()
                }).AsNoTracking()
            .OrderByDescending(x => x.Id).ToList();
        }

        public ProvinceViewModel Search(ProvinceSearchModel search)
        {
            return _context.Provinces
                .Where(x => !x.IsDeleted)
                .Select(x => new ProvinceViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Scope = x.Scope,
                    State = x.IsDeleted ? "حدف شده" : "حدف نشده",
                    Position = x.Position,
                    CreationDate = x.CreationDate.ToFarsi()
                }).AsNoTracking()
            .FirstOrDefault(x => x.Name == search.Name);
        }
    }
}
