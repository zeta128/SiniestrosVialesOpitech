using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Infraestructure.Persistence;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;

namespace SiniestrosVialesOpitech.Infraestructure.Repositories
{
    public class SiniestroVehiculoRepository(SiniestrosVialesWriteContext siniestrosVialesWriteContext) : ISiniestroVehiculoRepository
    {    
        public async Task CrearSiniestrosVehiculosAsync(List<SiniestrosVehiculos> siniestrosVehiculos)
        {
            await siniestrosVialesWriteContext
            .Set<SiniestrosVehiculos>()
            .AddRangeAsync(siniestrosVehiculos);
        }
    }
}
