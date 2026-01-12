
namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class Vehiculos
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

    public virtual ICollection<SiniestrosVehiculos> SiniestrosVehiculos { get; set; } = new List<SiniestrosVehiculos>();

    public virtual ICollection<SiniestrosVictimas> SiniestrosVictimas { get; set; } = new List<SiniestrosVictimas>();
}
