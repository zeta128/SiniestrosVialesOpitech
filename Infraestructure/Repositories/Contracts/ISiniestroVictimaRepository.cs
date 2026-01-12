using SiniestrosVialesOpitech.Domain.Entities;


namespace SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts
{
    public interface ISiniestroVictimaRepository
    {
        Task CrearSiniestrosVictimasAsync(List<SiniestrosVictimas> siniestrosVictimas);       
    }
}
