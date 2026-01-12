using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface IVehiculoRepository
    {
        Task CrearVehiculosAsync(List<Vehiculos> vehiculos);
        Task<List<Vehiculos>> ObtenerVehiculosPorIdSiniestroAsync(int idSiniestro);

    }
}
