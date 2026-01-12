using Ardalis.Specification;
using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface ISiniestroVehiculoRepository
    {
        Task CrearSiniestrosVehiculosAsync(List<SiniestrosVehiculos> siniestrosVehiculos);        
    }
}
