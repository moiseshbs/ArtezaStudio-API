namespace ArtezaStudio.Api.Entities
{
    public class UsuarioSeguidor
    {
        public Guid SeguidorId { get; set; }
        public Usuario Seguidor { get; set; }

        public Guid SeguidoId { get; set; }
        public Usuario Seguido { get; set; }

        public DateTime DataSeguimiento { get; set; } = DateTime.UtcNow;
    }
}
