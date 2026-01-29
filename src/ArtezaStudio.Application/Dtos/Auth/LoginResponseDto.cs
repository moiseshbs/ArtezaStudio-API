using ArtezaStudio.Application.Dtos.Usuario;

namespace ArtezaStudio.Application.Dtos.Auth
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public UsuarioDto Usuario { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}