using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Persistence.Configurations
{
    public class SiniestrosVictimaConfiguration : IEntityTypeConfiguration<SiniestrosVictimas>
    {
        public void Configure(EntityTypeBuilder<SiniestrosVictimas> entity)
        {
            entity.HasKey(e => e.IdSiniestroVictima).HasName("PK__Siniestr__2686FFFD015F3130");

            entity.HasIndex(e => e.IdSiniestro, "IX_SVIC_IdSiniestro");

            entity.HasIndex(e => new { e.IdSiniestro, e.IdVictima }, "UX_Siniestro_Victima").IsUnique();

            entity.Property(e => e.RolVictima).HasMaxLength(50);

            entity.HasOne(d => d.IdSiniestroNavigation).WithMany(p => p.SiniestrosVictimas)
                .HasForeignKey(d => d.IdSiniestro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SVIC_Siniestros");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.SiniestrosVictimas)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK_SVIC_Vehiculos");

            entity.HasOne(d => d.IdVictimaNavigation).WithMany(p => p.SiniestrosVictimas)
                .HasForeignKey(d => d.IdVictima)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SVIC_Victimas");
        }
    }
}
