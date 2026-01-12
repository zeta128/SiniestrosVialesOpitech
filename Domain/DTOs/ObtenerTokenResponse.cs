namespace SiniestrosVialesOpitech.Domain.DTOs
{
    public class ObtenerTokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
