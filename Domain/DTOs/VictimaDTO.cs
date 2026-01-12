
namespace SiniestrosVialesOpitech.Domain.DTOs;

public  class VictimaDTO
{
    public int IdVictima { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public short? Edad { get; set; }

    public string? Sexo { get; set; }

    public string Condicion { get; set; } = null!;
    public string? RolVictima { get; set; }

}
