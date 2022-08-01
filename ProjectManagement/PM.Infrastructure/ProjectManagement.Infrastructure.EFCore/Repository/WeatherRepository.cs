using Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Contracts.Weather;
using ProjectManagement.Domain.WeatherAgg;

namespace ProjectManagement.Infrastructure.EFCore.Repository
{
    public class WeatherRepository : BaseRepository<ushort, Weather>, IWeatherRepository
    {
        #region Constructor

        private readonly ProjectContext _context;

        public WeatherRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }


        #endregion

        public WeatherViewModel GetWeatherOfCityBy(ushort cityId)
        {
            return _context.Weathers
                .Include(x => x.City)
                .Where(x => !x.City.IsDeleted)
                .Select(x => new WeatherViewModel
                {
                    Id = x.Id,
                    CityId = x.CityId,
                    GeneralCondition = x.GeneralCondition,
                    CreationDate = x.CreationDate.ToFarsi(),
                    CurrentTemperature = x.CurrentTemperature
                }).AsNoTracking()
                .FirstOrDefault(x => x.CityId == cityId);
        }
    }
}