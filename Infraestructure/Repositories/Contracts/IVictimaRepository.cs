using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface IVictimaRepository
    {
        Task CrearVictimasAsync(List<Victimas> victimas);
       
    }
}
