using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.CityAgg;
using ProjectManagement.Domain.WeatherAgg;

namespace ProjectManagement.Infrastructure.EFCore.Maping
{
    public class WeatherMapping : IEntityTypeConfiguration<Weather>
    {
        public void Configure(EntityTypeBuilder<Weather> builder)
        {
            builder.ToTable("Weathers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GeneralCondition).HasMaxLength(30).IsRequired();
        }
    }
}
