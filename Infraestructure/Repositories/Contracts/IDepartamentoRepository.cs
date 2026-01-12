

using SiniestrosVialesOpitech.Domain.Entities;

namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface IDepartamentoRepository
    {
        Task<bool> ExisteDeptoPorIdAsync(int idDepto);
        Task<Departamentos?> ObtenerDeptoPorId(int idDepto);      
    }
}
