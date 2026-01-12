using Ardalis.Specification;
using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface ISiniestroVialRepository
    {
        Task CrearSiniestroVialAsync(Siniestros siniestroVial);
        Task<List<Siniestros>> ObtenerSiniestroVialPorSpecAsync(ISpecification<Siniestros> genericSpecification);
        Task<int> CountBySpecAsync(ISpecification<Siniestros> siniestrosSpecification);
    }
}
