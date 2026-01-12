using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Domain.Specifications;

namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface ISiniestroVialRepository
    {
        Task CrearSiniestroVialAsync(Siniestros siniestroVial);
        Task<List<Siniestros>> ObtenerSiniestroVialPorSpecAsync(GenericSpecification<Siniestros> genericSpecification);
    }
}
