namespace ArtezaStudio.Domain.Entities
{
    public class Comentario
    {
        public long Id { get; set; }
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataComentario { get; set; } = DateTime.UtcNow;

        public long PublicacaoId { get; set; }
        public Publicacao Publicacao { get; set; } = new();

        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new();
    }
}