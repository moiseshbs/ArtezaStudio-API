namespace ArtezaStudio.Api.Entities
{
    public class Comentario
    {
        public Guid Id { get; set; }
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataComentario { get; set; } = DateTime.UtcNow;

        public Guid PublicacaoId { get; set; }
        public Publicacao Publicacao { get; set; } = new();

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new();
    }
}
