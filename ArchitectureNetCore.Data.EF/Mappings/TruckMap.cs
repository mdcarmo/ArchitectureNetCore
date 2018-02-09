using ArchitectureNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchitectureNetCore.Data.EF.Mappings
{
    public class TruckMap : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Truck");

            builder.Property(p => p.ID)
                .ValueGeneratedNever();

            builder.Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
