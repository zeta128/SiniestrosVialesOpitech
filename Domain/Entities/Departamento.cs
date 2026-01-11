

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public short CodigoDane { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
