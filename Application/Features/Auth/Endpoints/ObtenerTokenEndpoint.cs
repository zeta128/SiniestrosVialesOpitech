using Carter;
using MediatR;
using SiniestrosVialesOpitech.Application.Common;
using SiniestrosVialesOpitech.Application.Features.Auth.V1.Queries;


namespace SiniestrosVialesOpitech.Application.Features.Auth.Endpoints
{
    public class ObtenerTokenEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}obtener-token",
            async (HttpContext httpContext, ObtenerTokenQuery request, ISender sender) =>
            {
                var respuesta = await sender.Send(request);

                return Results.Ok(respuesta);
            }).WithTags(Tags.Auth.Tag)
            .WithSummary("Endpoint obtener token")
            .WithDescription("<b>En el momento el método no necesita nombre de usuario y contraseña, pero el login puede ser configurado después</b> ")
            ;
        }
    }
}