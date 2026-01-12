using MediatR;
using SiniestrosVialesOpitech.Application.Common.Responses;
using SiniestrosVialesOpitech.Application.Features.Auth.V1.DTOs;


namespace SiniestrosVialesOpitech.Application.Features.Auth.V1.Queries
{
    public class ObtenerTokenQuery() : IRequest<BaseResponse<ObtenerTokenResponse>>
    {

    }
}