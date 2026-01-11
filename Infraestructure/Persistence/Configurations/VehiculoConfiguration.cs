using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Persistence.Configurations
{
    public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> entity)
        {
            entity.HasKey(e => e.IdVehiculo).HasName("PK__Vehiculo__708612150428E236");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Servicio).HasMaxLength(30);
            entity.Property(e => e.TipoVehiculo).HasMaxLength(50);
        }
    }
}
