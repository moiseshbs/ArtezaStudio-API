using ArtezaStudio.Application.Dtos.Publicacao;
using ArtezaStudio.Application.Dtos.Usuario;

namespace ArtezaStudio.Application.Dtos.Visualizacao
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
