using Mapster;
using MediatR;
using SiniestrosVialesOpitech.Domain.DTOs;
using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Domain.Options.Pagination;
using SiniestrosVialesOpitech.Domain.Specifications.SiniestrosViales;
using SiniestrosVialesOpitech.Domain.Wrappers;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;

namespace SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Queries.Handlers
{

    public class ObtenerListaSiniestrosQueryHandler : IRequestHandler<ObtenerListaSiniestrosQuery, Response<Paged<SiniestroDatosBasicosResponseDTO>>>
    {

        private readonly IConfiguration _configuration;
        private readonly ISiniestroVialRepository _siniestroVialRepository;
        private readonly ITipoSiniestroRepository _tipoSiniestroRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IMunicipioRepository _municipioRepository;
        private readonly IVehiculoRepository _vehiculoRepository;

        public ObtenerListaSiniestrosQueryHandler(
            IConfiguration configuration, 
            ISiniestroVialRepository siniestroVialRepository,
            ITipoSiniestroRepository tipoSiniestroRepository,
            IDepartamentoRepository departamentoRepository,
            IMunicipioRepository municipioRepository,
            IVehiculoRepository vehiculoRepository)
        {
            _configuration = configuration;
            _siniestroVialRepository = siniestroVialRepository;
            _departamentoRepository = departamentoRepository;
            _municipioRepository = municipioRepository;
            _tipoSiniestroRepository = tipoSiniestroRepository;
            _vehiculoRepository = vehiculoRepository;
        }




        public async Task<Response<Paged<SiniestroDatosBasicosResponseDTO>>> Handle(ObtenerListaSiniestrosQuery request, CancellationToken cancellationToken)
        {

            var ObtenerSiniestrosVialesSpecification = new SiniestrosVialesSpecification(request.NumeroDePagina, request.NumeroDeFilas, request.Filtros, request.CampoDeOrdenamiento, request.DireccionDeOrdenamiento);
            var listaSiniestrosViales = await _siniestroVialRepository.ObtenerSiniestroVialPorSpecAsync(ObtenerSiniestrosVialesSpecification);

            var ObtenerSiniestrosTotalSpec = new SiniestrosVialesSpecification(request.NumeroDePagina, request.NumeroDeFilas, request.Filtros, request.CampoDeOrdenamiento, request.DireccionDeOrdenamiento, true);
            int totalSiniestros = await _siniestroVialRepository.CountBySpecAsync(ObtenerSiniestrosTotalSpec);

            var listadoRespuesta = await MapearDatosSiniestrosViales(listaSiniestrosViales, request.IncluirVehiculos.Value);

            var ListadoRespuestaPaginado = new Paged<SiniestroDatosBasicosResponseDTO>(listadoRespuesta, totalSiniestros, request.NumeroDePagina, request.NumeroDeFilas);
            return new Response<Paged<SiniestroDatosBasicosResponseDTO>>(ListadoRespuestaPaginado.MetaData, ListadoRespuestaPaginado);

        }
        private async Task<List<SiniestroDatosBasicosResponseDTO>> MapearDatosSiniestrosViales(List<Siniestros> listaSiniestros, bool incluirVehiculos)
        {
            var listadoRespuesta = new List<SiniestroDatosBasicosResponseDTO>();

            foreach (var siniestro in listaSiniestros)
            {
                var municipioSiniestro = await _municipioRepository.ObtenerMunicipioPorId(siniestro.IdMunicipio);
                var deptoSiniestro = await _departamentoRepository.ObtenerDeptoPorId(siniestro.MunicipioNavigation.IdDepartamento);
                var tipoSiniestro = await _tipoSiniestroRepository.ObtenerTipoSiniestroPorIdAsync(siniestro.IdTipoSiniestro);

                var vehiculosSiniestro = incluirVehiculos ? await _vehiculoRepository.ObtenerVehiculosPorIdSiniestroAsync(siniestro.IdSiniestro):null;
      
                listadoRespuesta.Add(new SiniestroDatosBasicosResponseDTO()
                {
                    FechaSiniestro = siniestro.Fecha,
                    Departamento = deptoSiniestro!.Nombre,
                    Municipio = municipioSiniestro!.Nombre,
                    TipoSiniestro = tipoSiniestro!.Nombre,
                    NumeroVictimas = siniestro.NumeroVictimas ?? 0,
                    Descripcion = siniestro.Descripcion ?? "",
                    FechaRegistro = siniestro.FechaRegistro,
                    Vehiculos = incluirVehiculos ? vehiculosSiniestro.Adapt<List<VehiculoDTO>>():null
                });

            }
            return listadoRespuesta;
        }


    }
}