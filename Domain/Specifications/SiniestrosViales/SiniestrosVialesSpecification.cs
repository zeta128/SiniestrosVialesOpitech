using Ardalis.Specification;
using SiniestrosVialesOpitech.Application.Common;
using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Domain.Options.Pagination;


namespace SiniestrosVialesOpitech.Domain.Specifications.SiniestrosViales
{
    public class SiniestrosVialesSpecification : Specification<Siniestros>
    {
        private readonly Dictionary<string, string> CampoOrdenamientoMappings = new(StringComparer.OrdinalIgnoreCase)
        {
            { "id", nameof(Siniestros.IdSiniestro) },
            { "fechasiniestro", nameof(Siniestros.Fecha) },
            { "fecharegistro", nameof(Siniestros.FechaRegistro) },
            { "numerovictimas", nameof(Siniestros.NumeroVictimas) }            
        };

        public SiniestrosVialesSpecification(int? numeroDePagina, int? numeroDeFilas, List<FiltroDto> filtros, string? campoOrdenamiento, string? direccionOrdenamiento, bool omitirPaginacion = false)
        {

            var numeroFilas = numeroDeFilas ?? ValuesByDefaultPaged.NumberFiles_ByDefault;
            var numeroPagina = numeroDePagina ?? ValuesByDefaultPaged.NumberPage_ByDefault;


            Query.Include(x => x.MunicipioNavigation);
            Query.Include(x => x.TipoSiniestroNavigation);


            #region captura de filtros recibidos

            var fechaSiniestroInicioFiltro = filtros.Where(x => x.CampoFiltrar.ToLower().Equals("fechainiciosiniestro", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var fechaSiniestroFinFiltro = filtros.Where(x => x.CampoFiltrar.ToLower().Equals("fechafinsiniestro", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var fechaRegistroInicioFiltro = filtros.Where(x => x.CampoFiltrar.ToLower().Equals("fechainicioregistro", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var fechaRegistroFinFiltro = filtros.Where(x => x.CampoFiltrar.ToLower().Equals("fechafinregistro", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var departamentoFiltro = filtros.Where(x => x.CampoFiltrar.ToLower().Equals("departamentoid", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var municipioFiltro = filtros.Where(x => x.CampoFiltrar.ToLower().Equals("municipioid", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var tiposiniestroFiltro = filtros.Where(x => x.CampoFiltrar.ToLower().Equals("tiposiniestroid", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            
            #endregion

            #region validación filtros
            
            DateTime? fechaInicioSiniestro = fechaSiniestroInicioFiltro != null
            ? DateTime.Parse(fechaSiniestroInicioFiltro.ValorFiltrar)
            : null;

            DateTime? fechaFinSiniestro = fechaSiniestroFinFiltro != null
                ? DateTime.Parse(fechaSiniestroFinFiltro.ValorFiltrar)
                : null;
            DateTime? fechaInicioRegistro = fechaRegistroInicioFiltro != null
            ? DateTime.Parse(fechaRegistroInicioFiltro.ValorFiltrar)
            : null;

            DateTime? fechaFinRegistro = fechaRegistroFinFiltro != null
                ? DateTime.Parse(fechaRegistroFinFiltro.ValorFiltrar)
                : null;

            int? deptoId = departamentoFiltro != null
                ? int.Parse(departamentoFiltro.ValorFiltrar)
                : null;
            int? municipioId = municipioFiltro != null
                ? int.Parse(municipioFiltro.ValorFiltrar)
                : null;
            int? tipoSiniestroId = tiposiniestroFiltro != null
                ? int.Parse(tiposiniestroFiltro.ValorFiltrar)
                : null;

            #endregion

            #region aplicación filtros y ordenamientos

            if (fechaInicioSiniestro.HasValue)
            {
                Query.Where(x => x.Fecha >= fechaInicioSiniestro.Value);
            }

            if (fechaFinSiniestro.HasValue)
            {
                // Ajusta la fecha fin al último instante del día (23:59:59.9999999)
                fechaFinSiniestro = fechaFinSiniestro.Value.Date.AddDays(1).AddTicks(-1);
                Query.Where(x => x.Fecha <= fechaFinSiniestro.Value);
            }
            if (fechaInicioRegistro.HasValue)
            {
                Query.Where(x => x.FechaRegistro >= fechaInicioRegistro.Value);
            }

            if (fechaFinRegistro.HasValue)
            {
                // Ajusta la fecha fin al último instante del día (23:59:59.9999999)
                fechaFinRegistro = fechaFinRegistro.Value.Date.AddDays(1).AddTicks(-1);
                Query.Where(x => x.FechaRegistro <= fechaFinRegistro.Value);
            }
            if (deptoId.HasValue)
            {     
                Query.Where(x => x.MunicipioNavigation.IdDepartamento == deptoId.Value);
            }
            if (municipioId.HasValue)
            {
                Query.Where(x => x.IdMunicipio == municipioId.Value);
            }
            if (tipoSiniestroId.HasValue)
            {
                Query.Where(x => x.IdTipoSiniestro == tipoSiniestroId.Value);
            }

            if (CampoOrdenamientoMappings.TryGetValue(campoOrdenamiento.ToLower(), out var valorMapeado))
            {
                Query.OrderBy(valorMapeado, direccionOrdenamiento);
            }
            else
            {
                Query.OrderBy(nameof(Siniestros.FechaRegistro), ValuesByDefaultPaged.DIRECCIONORDENAMIENTO);
            }
            if (!omitirPaginacion)
                Query.Skip((numeroPagina - 1) * numeroFilas).Take(numeroFilas);
            
            #endregion
        }



    }
}