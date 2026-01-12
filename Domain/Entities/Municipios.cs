

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class Municipios
{
    public int IdMunicipio { get; set; }

    public int CodigoDane { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdDepartamento { get; set; }

    public virtual Departamentos IdDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Siniestros> Siniestros { get; set; } = new List<Siniestros>();
}
