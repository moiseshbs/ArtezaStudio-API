namespace ArtezaStudio.Domain.Entities
{
    public class Visualizacao
    {
        public Guid Id { get; set; }
        public DateTime DataVisualizacao { get; set; } = DateTime.UtcNow;

        public Guid PublicacaoId { get; set; }
        public Publicacao Publicacao { get; set; } = new();
    
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new();
    }
}
