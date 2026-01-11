using System;
using System.Collections.Generic;

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class Victima
{
    public int IdVictima { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public short? Edad { get; set; }

    public string? Sexo { get; set; }

    public string Condicion { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<SiniestrosVictima> SiniestrosVictimas { get; set; } = new List<SiniestrosVictima>();
}
