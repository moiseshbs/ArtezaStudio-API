namespace ArtezaStudio.Api.Dtos.Usuario
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string ImagemPerfilUrl { get; set; }
        public bool IsAtivo { get; set; }
    }
}
