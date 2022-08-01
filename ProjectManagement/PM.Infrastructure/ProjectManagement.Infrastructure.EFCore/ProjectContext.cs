using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.CityAgg;
using ProjectManagement.Domain.ProvinceAgg;
using ProjectManagement.Domain.WeatherAgg;
using ProjectManagement.Infrastructure.EFCore.Maping;

namespace ProjectManagement.Infrastructure.EFCore
{
    public class ProjectContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CityMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Seed<Province>(new List<Province>
            {
                new Province("تهران", "مرکز", 1500, id : 1),
                new Province("آذربایجان غربی", "شمال غرب", 2200, id : 2),
                new Province("آذربایجان شرقی", "شمال غرب", 1900, id : 3)
            });

            modelBuilder.Seed<Weather>(new List<Weather>
            {
                new Weather("گرم خشک", "+32", 1, id : 1),
                new Weather("گرم مرطوب", "+22", 2, id : 2),
                new Weather("گرم مرطوب", "+21", 3, id : 3)
            });

            modelBuilder.Seed<City>(new List<City>
            {
                new City("تهران", "مرکز", 270, 1, id : 1),
                new City("ارومیه", "شمال غرب", 65, 2, id : 2),
                new City("تبریز", "شمال غرب", 145, 3, id : 3)
            });

            //modelBuilder.Entity<Province>().HasData(
            //    new Province("تهران", "مرکز", 1500, id: 1),
            //    new Province("آذربایجان غربی", "شمال غرب", 2200, id: 2),
            //    new Province("آذربایجان شرقی", "شمال غرب", 1900, id: 3)
            //    );

            //modelBuilder.Entity<City>().HasData(
            //    new City("تهران", "مرکز", 270, 1, id: 1),
            //    new City("ارومیه", "شمال غرب", 65, 2, id: 2),
            //    new City("تبریز", "شمال غرب", 145, 3, id: 3)
            //    );

            //modelBuilder.Entity<Weather>().HasData(
            //    new Weather("گرم خشک", "+32", 1, id: 1),
            //    new Weather("گرم مرطوب", "+22", 2, id: 2),
            //    new Weather("گرم مرطوب", "+21", 3, id: 3)
            //    );

            base.OnModelCreating(modelBuilder);
        }
    }
}