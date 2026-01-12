
namespace SiniestrosVialesOpitech.Domain.DTOs;

public class VehiculoDTO
{
    public string? Placa { get; set; }

    public string TipoVehiculo { get; set; } = null!;

    public string? Marca { get; set; }

    public short Modelo { get; set; }

    public string? Color { get; set; }

    public string? Servicio { get; set; }
    public string? RolVehiculo { get; set; }

}
