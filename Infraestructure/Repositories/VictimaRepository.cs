using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Infraestructure.Persistence;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;


namespace SiniestrosVialesOpitech.Infraestructure.Repositories
{
    public class VictimaRepository(SiniestrosVialesWriteContext siniestrosVialesWriteContext) : IVictimaRepository
    {
        public async Task CrearVictimasAsync(List<Victimas> victimas)
        {
            await siniestrosVialesWriteContext
            .Set<Victimas>()
            .AddRangeAsync(victimas);
        }
    }
}
