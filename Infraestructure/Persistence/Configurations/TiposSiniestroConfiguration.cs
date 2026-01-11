using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Persistence.Configurations
{
    public class TiposSiniestroConfiguration : IEntityTypeConfiguration<TiposSiniestro>
    {
        public void Configure(EntityTypeBuilder<TiposSiniestro> entity)
        {
            entity.HasKey(e => e.IdTipoSiniestro).HasName("PK__TiposSin__E60A8FB9AC354655");

            entity.HasIndex(e => e.Codigo, "UX_TiposSiniestros_Codigo")
                .IsUnique()
                .HasFilter("([Codigo] IS NOT NULL)");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}
