
using Ardalis.GuardClauses;

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class Victimas
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

    public virtual ICollection<SiniestrosVictimas> SiniestrosVictimas { get; set; } = new List<SiniestrosVictimas>();

    public Victimas()
    {
            
    }
    public Victimas(
        string? tipoDocumento,
        string? numeroDocumento,
        string nombres,
        string apellidos,
        short? edad,
        string? sexo,
        string condicion)
    {
        TipoDocumento = tipoDocumento;
        NumeroDocumento = numeroDocumento;
        Nombres = nombres;
        Apellidos = apellidos;
        Edad = edad;
        Sexo = sexo;
        Condicion = condicion;
    }

    #region Registrar Victimas 
    public static Victimas CrearVictima(
        string? tipoDocumento,
        string? numeroDocumento,
        string nombres,
        string apellidos,
        short? edad,
        string? sexo,
        string condicion
        )
    {
        Guard.Against.NullOrEmpty(nombres, "Los nombres no pueden ir vacios");

        Guard.Against.NullOrEmpty(apellidos, "Los apellidos no pueden ir vacios");
        Guard.Against.NullOrEmpty(condicion, "La condicion no puede ir vacia");

        return new Victimas(
            tipoDocumento, numeroDocumento, nombres, apellidos, edad, sexo, condicion 
        );
        return null!;
    }

    #endregion
}
