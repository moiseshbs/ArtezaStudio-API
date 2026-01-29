using ArtezaStudio.Application.Dtos.Comentario;
using ArtezaStudio.Application.Dtos.Curtida;
using ArtezaStudio.Application.Dtos.Tag;
using ArtezaStudio.Application.Dtos.Usuario;
using ArtezaStudio.Application.Dtos.Visualizacao;
using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Application.Dtos.Publicacao
{
    public class PublicacaoDto
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public DateTime DataPublicacao { get; set; }

        public ICollection<ComentarioDto>? Comentarios { get; set; }

        public ICollection<CurtidaDto>? Curtidas { get; set; }

        public ICollection<VisualizacaoDto>? Visualizacoes { get; set; }

        public ICollection<PublicacaoTagDto>? PublicacaoTags { get; set; }

        public long UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
