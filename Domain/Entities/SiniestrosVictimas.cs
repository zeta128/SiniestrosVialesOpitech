

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class SiniestrosVictimas
{
    public int IdSiniestroVictima { get; set; }

    public int IdSiniestro { get; set; }

    public int IdVictima { get; set; }

    public int? IdVehiculo { get; set; }

    public string? RolVictima { get; set; }

    public virtual Siniestros SiniestroNavigation { get; set; } = null!;

    public virtual Vehiculos? VehiculoNavigation { get; set; }

    public virtual Victimas VictimaNavigation { get; set; } = null!;
}
