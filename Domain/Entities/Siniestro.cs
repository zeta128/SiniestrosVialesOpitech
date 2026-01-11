using System;
using System.Collections.Generic;

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class Siniestro
{
    public int IdSiniestro { get; set; }

    public DateTime Fecha { get; set; }

    public int IdMunicipio { get; set; }

    public int IdTipoSiniestro { get; set; }

    public int? NumeroVictimas { get; set; }

    public string? Descripcion { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Municipio IdMunicipioNavigation { get; set; } = null!;

    public virtual TiposSiniestro IdTipoSiniestroNavigation { get; set; } = null!;

    public virtual ICollection<SiniestrosVehiculo> SiniestrosVehiculos { get; set; } = new List<SiniestrosVehiculo>();

    public virtual ICollection<SiniestrosVictima> SiniestrosVictimas { get; set; } = new List<SiniestrosVictima>();
}
