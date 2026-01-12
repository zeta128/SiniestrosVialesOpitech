using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Persistence.Configurations
{
    public class SiniestroConfiguration : IEntityTypeConfiguration<Siniestros>
    {
        public void Configure(EntityTypeBuilder<Siniestros> entity)
        {
            entity.HasKey(e => e.IdSiniestro).HasName("PK__Siniestr__B3D1483E05E511E4");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Siniestros)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Siniestros_Municipios");

            entity.HasOne(d => d.IdTipoSiniestroNavigation).WithMany(p => p.Siniestros)
                .HasForeignKey(d => d.IdTipoSiniestro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Siniestros_Tipos");
        }
    }
}
