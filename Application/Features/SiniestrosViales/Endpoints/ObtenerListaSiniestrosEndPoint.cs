using Carter;
using MediatR;
using SiniestrosVialesOpitech.Application.Common;
using SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Queries;
using System.Text.Json;


namespace SiniestrosVialesOpitech.Application.Features.Auth.Endpoints
{
    public class ObtenerListaSiniestrosEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}obtener-listado-siniestros",
            async (HttpContext httpContext, ObtenerListaSiniestrosQuery request, ISender sender) =>
            {
                var respuesta = await sender.Send(request);
                httpContext.Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(respuesta.Data.MetaData));
                return Results.Ok(respuesta);
            }).WithTags(Tags.Siniestros.Tag)
             .RequireAuthorization()
             .WithDescription("<b>Filtros:</b></br> " +
            "fechainiciosiniestro, fechafinsiniestro </br>" +
            "fechainicioregistro, fechafinregistro </br>" +
            "departamentoid, municipioid,tiposiniestroid</br></br>"+
            "<b>Ordenamientos:</b></br> " +
             "id, fechasiniestro, fecharegistro, numerovictimas  </br>"

             )         
            .WithSummary("Endpoint obtener listado de siniestros viales paginados");
        }
    }
}


