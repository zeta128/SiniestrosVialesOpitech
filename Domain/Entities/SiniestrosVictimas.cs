

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class SiniestrosVictimas
{
    public int IdSiniestroVictima { get; set; }

    public int IdSiniestro { get; set; }

    public int IdVictima { get; set; }

    public int? IdVehiculo { get; set; }

    public string? RolVictima { get; set; }

    public virtual Siniestros IdSiniestroNavigation { get; set; } = null!;

    public virtual Vehiculos? IdVehiculoNavigation { get; set; }

    public virtual Victimas IdVictimaNavigation { get; set; } = null!;
}
