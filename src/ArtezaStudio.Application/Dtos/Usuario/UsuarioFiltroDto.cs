namespace ArtezaStudio.Application.Dtos.Usuario
{
    public class UsuarioFiltroDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? ImagemPerfilUrl { get; set; }
    }
}
