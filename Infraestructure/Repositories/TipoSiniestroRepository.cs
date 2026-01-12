using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Infraestructure.Persistence;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;

namespace SiniestrosVialesOpitech.Infraestructure.Repositories
{
    public class TipoSiniestroRepository(SiniestrosVialesWriteContext siniestrosVialesWriteContext, SiniestrosVialesReadContext siniestrosVialesReadContext) : ITipoSiniestroRepository
    {
      
        public async Task<bool> ExisteTipoSiniestroPorIdAsync(int idTipoSiniestro)
        {
            return await siniestrosVialesReadContext.Set<TiposSiniestros>()
                .AsNoTracking()
                .AnyAsync(m => m.IdTipoSiniestro == idTipoSiniestro);
        }

        public async Task<TiposSiniestros?> ObtenerTipoSiniestroPorIdAsync(int idTipoSiniestro)
        {
            return await siniestrosVialesReadContext.Set<TiposSiniestros>()
                .Where(ts => ts.IdTipoSiniestro == idTipoSiniestro)
                .FirstOrDefaultAsync();
                
        }

    }
}
