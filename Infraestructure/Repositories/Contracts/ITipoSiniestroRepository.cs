

namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface ITipoSiniestroRepository
    {
        Task<bool> ExisteTipoSiniestroPorIdAsync(int idTipoSiniestro);
    }
}
