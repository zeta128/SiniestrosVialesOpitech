using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Persistence.Configurations
{
    public class SiniestrosVehiculoConfiguration : IEntityTypeConfiguration<SiniestrosVehiculos>
    {
        public void Configure(EntityTypeBuilder<SiniestrosVehiculos> entity)
        {
            entity.HasKey(e => e.IdSiniestroVehiculo).HasName("PK__Siniestr__60831233D66D8399");

            entity.HasIndex(e => e.IdSiniestro, "IX_SV_IdSiniestro");

            entity.HasIndex(e => new { e.IdSiniestro, e.IdVehiculo }, "UX_Siniestro_Vehiculo").IsUnique();

            entity.Property(e => e.RolVehiculo).HasMaxLength(50);

            entity.HasOne(d => d.SiniestroNavigation).WithMany(p => p.SiniestrosVehiculos)
                .HasForeignKey(d => d.IdSiniestro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SV_Siniestros");

            entity.HasOne(d => d.VehiculoNavigation).WithMany(p => p.SiniestrosVehiculos)
                .HasForeignKey(d => d.IdVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SV_Vehiculos");
        }
    }
}
