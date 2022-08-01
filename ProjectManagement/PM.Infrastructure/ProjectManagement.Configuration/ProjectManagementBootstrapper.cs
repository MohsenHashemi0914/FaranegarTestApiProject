using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Application;
using ProjectManagement.Application.Contracts.City;
using ProjectManagement.Application.Contracts.Province;
using ProjectManagement.Application.Contracts.Weather;
using ProjectManagement.Domain.CityAgg;
using ProjectManagement.Domain.ProvinceAgg;
using ProjectManagement.Domain.WeatherAgg;
using ProjectManagement.Infrastructure.EFCore;
using ProjectManagement.Infrastructure.EFCore.Repository;

namespace ProjectManagement.Configuration
{
    public static class ProjectManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityApplication, CityApplication>();

            services.AddScoped<IWeatherRepository, WeatherRepository>();
            services.AddScoped<IWeatherApplication, WeatherApplication>();

            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IProvinceApplication, ProvinceApplication>();

            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(connectionString));
        }
    }
}