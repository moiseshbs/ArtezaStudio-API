namespace ArtezaStudio.Domain.Entities
{
    public class Visualizacao
    {
        public long Id { get; set; }
        public DateTime DataVisualizacao { get; set; } = DateTime.UtcNow;

        public long PublicacaoId { get; set; }
        public Publicacao Publicacao { get; set; } = new();
    
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new();
    }
}