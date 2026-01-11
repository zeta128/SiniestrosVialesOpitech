using System;
using System.Collections.Generic;

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class SiniestrosVehiculo
{
    public int IdSiniestroVehiculo { get; set; }

    public int IdSiniestro { get; set; }

    public int IdVehiculo { get; set; }

    public string? RolVehiculo { get; set; }

    public virtual Siniestro IdSiniestroNavigation { get; set; } = null!;

    public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
}
