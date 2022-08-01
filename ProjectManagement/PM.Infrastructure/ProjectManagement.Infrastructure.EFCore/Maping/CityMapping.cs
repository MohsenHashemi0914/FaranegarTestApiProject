using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.CityAgg;
using ProjectManagement.Domain.WeatherAgg;

namespace ProjectManagement.Infrastructure.EFCore.Maping
{
    public class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Scope).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Position).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Province)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.ProvinceId);

            builder.HasOne(x => x.Weather)
                .WithOne(x => x.City)
                .HasForeignKey<Weather>(x => x.CityId);
        }
    }
}
