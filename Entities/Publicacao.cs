namespace ArtezaStudio.Api.Entities
{
    public class Publicacao
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty;
        public DateTime DataPublicacao { get; set; } = DateTime.UtcNow;

        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

        public ICollection<Curtida> Curtidas { get; set; } = new List<Curtida>();

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new();
    }
}