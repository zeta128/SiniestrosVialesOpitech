

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class Departamentos
{
    public int IdDepartamento { get; set; }

    public short CodigoDane { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Municipios> Municipios { get; set; } = new List<Municipios>();
}
