using ArtezaStudio.Api.Dtos.Publicacao;
using ArtezaStudio.Api.Dtos.Usuario;

namespace ArtezaStudio.Api.Dtos.Visualizacao
{
    public class VisualizacaoDto
    {
        public Guid Id { get; set; }
        public DateTime DataVisualizacao { get; set; }

        public Guid PublicacaoId { get; set; }
        public PublicacaoDto publicacao { get; set; }

        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
