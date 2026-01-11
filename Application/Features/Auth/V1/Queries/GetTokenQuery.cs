using MediatR;
using SiniestrosVialesOpitech.Application.Common.Wrappers;
using SiniestrosVialesOpitech.Application.Features.Auth.V1.DTOs;


namespace SiniestrosVialesOpitech.Application.Features.Auth.V1.Queries
{
    public class GetTokenQuery() : IRequest<BaseResponse<GetTokenResponse>>
    {

    }
}