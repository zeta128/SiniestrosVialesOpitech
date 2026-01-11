using SiniestrosVialesOpitech.Infraestructure.Persistence;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;


namespace SiniestrosVialesOpitech.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SiniestrosVialesWriteContext _SiniestrosVialesDBContext;


        public UnitOfWork(
            SiniestrosVialesWriteContext SiniestrosVialesDBContext)
        {
            _SiniestrosVialesDBContext = SiniestrosVialesDBContext;
        }
        public void Dispose()
        {
            _SiniestrosVialesDBContext.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await _SiniestrosVialesDBContext.SaveChangesAsync(cancellationToken);
    }
}
