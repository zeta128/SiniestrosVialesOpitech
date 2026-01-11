

namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface IUnitOfWork 
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
