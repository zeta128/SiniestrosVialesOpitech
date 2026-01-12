using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Domain.Specifications;

namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface IMunicipioRepository
    {        
        Task<bool> ExisteMunicipioPorIdAsync(int idMunicipio);
    }
}
