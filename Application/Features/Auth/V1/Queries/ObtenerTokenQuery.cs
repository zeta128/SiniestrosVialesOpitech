using MediatR;
using SiniestrosVialesOpitech.Application.Common.Responses;
using SiniestrosVialesOpitech.Domain.DTOs;


namespace SiniestrosVialesOpitech.Application.Features.Auth.V1.Queries
{
    public class ObtenerTokenQuery() : IRequest<BaseResponse<ObtenerTokenResponse>>
    {

    }
}