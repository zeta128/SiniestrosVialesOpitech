

using SiniestrosVialesOpitech.Domain.Entities;

namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface ITipoSiniestroRepository
    {
        Task<bool> ExisteTipoSiniestroPorIdAsync(int idTipoSiniestro);
        Task<TiposSiniestros?> ObtenerTipoSiniestroPorIdAsync(int idTipoSiniestro);
    }
}
