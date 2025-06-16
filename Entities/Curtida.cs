namespace ArtezaStudio.Api.Entities
{
    public class Curtida
    {
        public Guid Id { get; set; }
        public DateTime DataCurtida { get; set; } = DateTime.UtcNow;

        public Guid PublicacaoId { get; set; }
        public Publicacao Publicacao { get; set; } = new();

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new();
    }
}
