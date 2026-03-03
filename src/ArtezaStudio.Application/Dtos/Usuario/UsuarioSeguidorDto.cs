namespace ArtezaStudio.Application.Dtos.Usuario
{
    public class UsuarioSeguidorDto
    {
        public long SeguidorId { get; set; }
        public string SeguidorNome { get; set; }
        public string SeguidorUsername { get; set; }
        public string? SeguidorImagemPerfilUrl { get; set; }

        public long SeguidoId { get; set; }
        public string SeguidoNome { get; set; }
        public string SeguidoUsername { get; set; }
        public string? SeguidoImagemPerfilUrl { get; set; }
    }
}
