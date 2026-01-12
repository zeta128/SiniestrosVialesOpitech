using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Infraestructure.Persistence;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;


namespace SiniestrosVialesOpitech.Infraestructure.Repositories
{
    public class VehiculoRepository(SiniestrosVialesWriteContext siniestrosVialesWriteContext, SiniestrosVialesReadContext siniestrosVialesReadContext) : IVehiculoRepository
    {
        public async Task CrearVehiculosAsync(List<Vehiculos> vehiculos)
        {
            await siniestrosVialesWriteContext
            .Set<Vehiculos>()
            .AddRangeAsync(vehiculos);
        }
        public async Task<List<Vehiculos>> ObtenerVehiculosPorIdSiniestroAsync(int idSiniestro)
        {
            return await siniestrosVialesReadContext
            .Set<Vehiculos>()
            .AsNoTracking()
            .Where(v => v.SiniestrosVehiculos
            .Any(sv => sv.IdSiniestro == idSiniestro))
            .ToListAsync();
        }
    }
}
