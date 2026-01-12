

using SiniestrosVialesOpitech.Domain.Entities;

namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface IMunicipioRepository
    {        
        Task<bool> ExisteMunicipioPorIdAsync(int idMunicipio);
        Task<Municipios?> ObtenerMunicipioPorId(int idMunicipio);
    }
}
