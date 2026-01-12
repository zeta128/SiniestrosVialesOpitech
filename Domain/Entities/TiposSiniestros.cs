

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class TiposSiniestros
{
    public int IdTipoSiniestro { get; set; }

    public string? Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Siniestros> Siniestros { get; set; } = new List<Siniestros>();
}
