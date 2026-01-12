
using Ardalis.GuardClauses;

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

    public Vehiculos()
    {
            
    }
    public Vehiculos(
        string placa,
        string tipoVehiculo,
        string marca,
        short modelo,
        string color,
        string servicio)
    {
        Placa = placa;
        TipoVehiculo = tipoVehiculo;
        Marca = marca;
        Modelo = modelo;
        Color = color;
        Servicio = servicio;

    }

    #region Registrar Vehiculo 
    public static Vehiculos CrearVehiculo(
        string placa,
        string tipoVehiculo,
        string marca,
        short modelo,
        string color,
        string servicio
        )
    {
        Guard.Against.NullOrEmpty(placa, "La placa no puede ir vacia");

        Guard.Against.NullOrEmpty(tipoVehiculo, "El tipo de vehiculo no puede ir vacio");
    
        return new Vehiculos(
            placa,tipoVehiculo, marca,modelo,color,servicio
        );
        return null!;
    }

    #endregion

}
