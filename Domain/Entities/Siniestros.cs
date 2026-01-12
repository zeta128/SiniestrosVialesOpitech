

using Ardalis.GuardClauses;


namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class Siniestros
{
    public int IdSiniestro { get; set; }

    public DateTime Fecha { get; set; }

    public int IdMunicipio { get; set; }

    public int IdTipoSiniestro { get; set; }

    public int? NumeroVictimas { get; set; }

    public string? Descripcion { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Municipios IdMunicipioNavigation { get; set; } = null!;

    public virtual TiposSiniestros IdTipoSiniestroNavigation { get; set; } = null!;

    public virtual ICollection<SiniestrosVehiculos> SiniestrosVehiculos { get; set; } = new List<SiniestrosVehiculos>();

    public virtual ICollection<SiniestrosVictimas> SiniestrosVictimas { get; set; } = new List<SiniestrosVictimas>();

    public Siniestros()
    {       
    }
    public Siniestros(DateTime fecha,
        int idMunicipio,
        int idTipoSiniestro,
        int? numeroVictimas,
        string? descripcion)
    {
        Fecha = fecha;
        IdMunicipio = idMunicipio;
        IdTipoSiniestro = idTipoSiniestro;
        NumeroVictimas = numeroVictimas;
        Descripcion = descripcion;
    }
    #region Crear Siniestro Simple
    public static Siniestros CrearSiniestroSimple(
        DateTime fecha,
        int idMunicipio,
        int idTipoSiniestro,
        int? numeroVictimas,
        string? descripcion)
    {
        Guard.Against.Default(fecha, nameof(fecha));

        Guard.Against.OutOfRange(
            fecha,
            nameof(fecha),
            DateTime.MinValue,
            DateTime.UtcNow
        );

        Guard.Against.NegativeOrZero(idMunicipio, nameof(idMunicipio));
        Guard.Against.NegativeOrZero(idTipoSiniestro, nameof(idTipoSiniestro));
        return new Siniestros(
            fecha, idMunicipio,idTipoSiniestro,numeroVictimas,descripcion
        );
        return null!;
    }

    #endregion
}
