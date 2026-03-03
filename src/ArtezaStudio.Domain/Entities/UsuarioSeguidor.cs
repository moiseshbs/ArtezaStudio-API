namespace ArtezaStudio.Domain.Entities
{
    public class UsuarioSeguidor
    {
        public long SeguidorId { get; set; }
        public Usuario Seguidor { get; set; }

        public long SeguidoId { get; set; }
        public Usuario Seguido { get; set; }

        public DateTime DataSeguimiento { get; set; } = DateTime.UtcNow;
    }
}