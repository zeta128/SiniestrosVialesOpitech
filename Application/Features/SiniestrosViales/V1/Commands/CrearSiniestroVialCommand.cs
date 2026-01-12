using MediatR;
using SiniestrosVialesOpitech.Application.Common.Responses;
using SiniestrosVialesOpitech.Domain.DTOs;
using SiniestrosVialesOpitech.Domain.Entities;

namespace SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Queries
{
    public class CrearSiniestroVialCommand : IRequest<BaseResponse<bool>>
    {       
        public DateTime fecha { get; set; }
        public int idMunicipio { get; set; }
        public int IdTipoSiniestro { get; set; }
        public int? NumeroVictimas { get; set; }
        public string? Descripcion { get; set; }
        public List<VehiculoDTO>? Vehiculos { get; set; }
        public List<VictimaDTO>? Victimas { get; set; }
      


    }
}