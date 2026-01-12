using MediatR;
using SiniestrosVialesOpitech.Application.Common.Responses;

namespace SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Queries
{
    public class CrearSiniestroVialCommand : IRequest<BaseResponse<bool>>
    {       
        public DateTime fecha { get; set; }
        public int idMunicipio { get; set; }
        public int IdTipoSiniestro { get; set; }
        public int? NumeroVictimas { get; set; }
        public string? Descripcion { get; set; }
    }
}