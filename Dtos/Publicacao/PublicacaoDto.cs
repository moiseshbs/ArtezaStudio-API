using ArtezaStudio.Api.Dtos.Comentario;
using ArtezaStudio.Api.Dtos.Curtida;
using ArtezaStudio.Api.Dtos.Tag;
using ArtezaStudio.Api.Dtos.Usuario;
using ArtezaStudio.Api.Dtos.Visualizacao;
using ArtezaStudio.Api.Entities;

namespace ArtezaStudio.Api.Dtos.Publicacao
{
    public class PublicacaoDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public DateTime DataPublicacao { get; set; }

        public ICollection<ComentarioDto>? Comentarios { get; set; }

        public ICollection<CurtidaDto>? Curtidas { get; set; }

        public ICollection<VisualizacaoDto>? Visualizacoes { get; set; }

        public ICollection<PublicacaoTagDto>? PublicacaoTags { get; set; }

        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
