

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class SiniestrosVehiculos
{
    public int IdSiniestroVehiculo { get; set; }

    public int IdSiniestro { get; set; }

    public int IdVehiculo { get; set; }

    public string? RolVehiculo { get; set; }

    public virtual Siniestros SiniestroNavigation { get; set; } = null!;

    public virtual Vehiculos VehiculoNavigation { get; set; } = null!;
}
