using System;
using System.Collections.Generic;

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string? Placa { get; set; }

    public string TipoVehiculo { get; set; } = null!;

    public string? Marca { get; set; }

    public short? Modelo { get; set; }

    public string? Color { get; set; }

    public string? Servicio { get; set; }

    public DateTime FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<SiniestrosVehiculo> SiniestrosVehiculos { get; set; } = new List<SiniestrosVehiculo>();

    public virtual ICollection<SiniestrosVictima> SiniestrosVictimas { get; set; } = new List<SiniestrosVictima>();
}
