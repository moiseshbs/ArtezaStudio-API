using ArtezaStudio.Application.Dtos.Publicacao;
using ArtezaStudio.Application.Dtos.Usuario;

namespace ArtezaStudio.Application.Dtos.Visualizacao
{
    public class VisualizacaoDto
    {
        public long Id { get; set; }
        public DateTime DataVisualizacao { get; set; }

        public long PublicacaoId { get; set; }
        public PublicacaoDto publicacao { get; set; }

        public long UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
