namespace SiniestrosVialesOpitech.Application.Features.Auth.V1.DTOs
{
    public class ObtenerTokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
