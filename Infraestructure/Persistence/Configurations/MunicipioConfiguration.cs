using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Persistence.Configurations
{
    public class MunicipioConfiguration : IEntityTypeConfiguration<Municipios>
    {
        public void Configure(EntityTypeBuilder<Municipios> entity)
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__61005978A075231D");

            entity.HasIndex(e => e.IdDepartamento, "IX_Municipios_IdDepartamento");

            entity.HasIndex(e => e.CodigoDane, "UQ__Municipi__C285373068EE46A4").IsUnique();

            entity.Property(e => e.CodigoDane).HasColumnName("CodigoDANE");
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Municipios_Departamentos");
        }
    }
}
