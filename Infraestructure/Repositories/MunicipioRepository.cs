using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;


namespace SiniestrosVialesOpitech.Infraestructure.Repositories
{
    public class MunicipioRepository( SiniestrosVialesReadContext siniestrosVialesReadContext) : IMunicipioRepository
    {
        public async Task<bool> ExisteMunicipioPorIdAsync(int idMunicipio)
        {
            return await siniestrosVialesReadContext.Set<Municipios>()
                //.AsNoTracking()
                .AnyAsync(m => m.IdMunicipio == idMunicipio);
        }


    }
}
