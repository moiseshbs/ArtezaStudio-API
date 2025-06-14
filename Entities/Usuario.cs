namespace ArtezaStudio.Api.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public string ImagemPerfilUrl { get; set; } = string.Empty;
        public bool IsAtivo { get; set; } = true;

        public ICollection<Comentario>? Comentarios { get; set; }
    }
}
