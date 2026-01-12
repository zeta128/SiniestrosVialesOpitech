using Carter;
using MediatR;
using SiniestrosVialesOpitech.Application.Common;
using SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Queries;


namespace SiniestrosVialesOpitech.Application.Features.Auth.Endpoints
{
    public class CrearSiniestroVialEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}crear-siniestro-vial", async (CrearSiniestroVialCommand request, ISender sender) =>
            {
                return Results.Ok(await sender.Send(request));
            }).WithTags(Tags.Siniestros.Tag)
            .RequireAuthorization()
            .WithSummary("Endpoint registro de siniestros viales");
        }
    }
}