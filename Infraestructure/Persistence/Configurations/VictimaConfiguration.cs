using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Persistence.Configurations
{
    public class VictimaConfiguration : IEntityTypeConfiguration<Victima>
    {
        public void Configure(EntityTypeBuilder<Victima> entity)
        {
            entity.HasKey(e => e.IdVictima).HasName("PK__Victimas__EEA2961CCB22BCA5");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Condicion).HasMaxLength(50);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(5)
                .IsUnicode(false);
        }
    }
}
