using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Persistence.Configurations
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> entity)
        {

            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433D57A0B5A3");

            entity.HasIndex(e => e.CodigoDane, "UQ__Departam__C28537306C6750A6").IsUnique();

            entity.Property(e => e.CodigoDane).HasColumnName("CodigoDANE");
            entity.Property(e => e.Nombre).HasMaxLength(50);

        }
    }
}
