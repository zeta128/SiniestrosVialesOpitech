using Microsoft.EntityFrameworkCore;
using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;


namespace SiniestrosVialesOpitech.Infraestructure.Repositories
{
    public class DepartamentoRepository( SiniestrosVialesReadContext siniestrosVialesReadContext) : IDepartamentoRepository
    {
        public async Task<bool> ExisteDeptoPorIdAsync(int idDepto)
        {
            return await siniestrosVialesReadContext.Set<Departamentos>()
                .AsNoTracking()
                .AnyAsync(m => m.IdDepartamento == idDepto);
        }
        public async Task<Departamentos?> ObtenerDeptoPorId(int idDepto)
        {
            return await siniestrosVialesReadContext.Set<Departamentos>()
                .Where(m => m.IdDepartamento == idDepto)
                .FirstOrDefaultAsync();
        }

    }
}
