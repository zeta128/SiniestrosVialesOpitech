using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Infraestructure.Persistence;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;

namespace SiniestrosVialesOpitech.Infraestructure.Repositories
{
    public class SiniestroVictimaRepository(SiniestrosVialesWriteContext siniestrosVialesWriteContext) : ISiniestroVictimaRepository
    {
        public async Task CrearSiniestrosVictimasAsync(List<SiniestrosVictimas> siniestrosVictimas)
        {
            await siniestrosVialesWriteContext
            .Set<SiniestrosVictimas>()
            .AddRangeAsync(siniestrosVictimas);
        }
    }
}
