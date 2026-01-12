using MediatR;
using Microsoft.IdentityModel.Tokens;
using SiniestrosVialesOpitech.Application.Common.Responses;
using SiniestrosVialesOpitech.Domain.DTOs;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SiniestrosVialesOpitech.Application.Features.Auth.V1.Queries.Handlers
{
    public class ObtenerTokenQueryHandler : IRequestHandler<ObtenerTokenQuery, BaseResponse<ObtenerTokenResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public ObtenerTokenQueryHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<BaseResponse<ObtenerTokenResponse>> Handle(ObtenerTokenQuery request, CancellationToken cancellationToken)
        {
            ObtenerTokenResponse loginResponse = GenerarToken("test");
            return new BaseResponse<ObtenerTokenResponse>(loginResponse);
        }
        public ObtenerTokenResponse GenerarToken(string username)
        {
            var secretKey = _configuration["Jwt:SecretKey"]!;
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Claims: Puedes agregar más información aquí según sea necesario.
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "User") // Puedes agregar roles dinámicos.
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials
            );

            return new ObtenerTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
}
