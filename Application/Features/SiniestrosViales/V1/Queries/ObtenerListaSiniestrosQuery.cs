using MediatR;
using SiniestrosVialesOpitech.Application.Common;
using SiniestrosVialesOpitech.Domain.DTOs;
using SiniestrosVialesOpitech.Domain.Options.Pagination;
using SiniestrosVialesOpitech.Domain.Wrappers;


namespace SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Queries
{  
    public class ObtenerListaSiniestrosQuery : IRequest<Response<Paged<SiniestroDatosBasicosResponseDTO>>>
    {
        public ObtenerListaSiniestrosQuery() { }


        public ObtenerListaSiniestrosQuery(List<FiltroDto> filtros, int? numeroDePagina, int? numeroDeFilas, string campoDeOrdenamiento,
        string direccionDeOrdenamiento)
        {
            Filtros = filtros;
            NumeroDePagina = numeroDePagina;
            NumeroDeFilas = numeroDeFilas;
            CampoDeOrdenamiento = campoDeOrdenamiento;
            DireccionDeOrdenamiento = direccionDeOrdenamiento;

        }

        public List<FiltroDto> Filtros { get; set; } = [];
        public int? NumeroDePagina { get; set; }
        public int? NumeroDeFilas { get; set; }
        public string CampoDeOrdenamiento { get; set; } = string.Empty;
        public string DireccionDeOrdenamiento { get; set; } = string.Empty;
        public bool? IncluirVehiculos { get; set; } = false;
    }
}
