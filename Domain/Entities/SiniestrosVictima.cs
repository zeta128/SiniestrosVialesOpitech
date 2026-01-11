using System;
using System.Collections.Generic;

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class SiniestrosVictima
{
    public int IdSiniestroVictima { get; set; }

    public int IdSiniestro { get; set; }

    public int IdVictima { get; set; }

    public int? IdVehiculo { get; set; }

    public string? RolVictima { get; set; }

    public virtual Siniestro IdSiniestroNavigation { get; set; } = null!;

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }

    public virtual Victima IdVictimaNavigation { get; set; } = null!;
}
