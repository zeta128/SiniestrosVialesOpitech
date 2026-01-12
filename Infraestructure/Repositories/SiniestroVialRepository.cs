using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Domain.Specifications;
using SiniestrosVialesOpitech.Infraestructure.Persistence;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;

namespace SiniestrosVialesOpitech.Infraestructure.Repositories
{
    public class SiniestroVialRepository(SiniestrosVialesWriteContext siniestrosVialesWriteContext, SiniestrosVialesReadContext siniestrosVialesReadContext) : ISiniestroVialRepository
    {
        public async Task CrearSiniestroVialAsync(Siniestros siniestroVial)
        {
            await siniestrosVialesWriteContext.Set<Siniestros>().AddAsync(siniestroVial);
        }

        public async Task<List<Siniestros>> ObtenerSiniestroVialPorSpecAsync(GenericSpecification<Siniestros> siniestroSpecification)
        {
            return await siniestrosVialesReadContext.Set<Siniestros>()
                                          .WithSpecification(siniestroSpecification)
                                          .ToListAsync();
        }
    }
}
