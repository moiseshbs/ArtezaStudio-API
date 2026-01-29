using ArtezaStudio.Application.Dtos.Publicacao;
using ArtezaStudio.Application.Dtos.Usuario;

namespace ArtezaStudio.Application.Dtos.Comentario
{
    public class ComentarioDto
    {
        public Guid Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataComentario { get; set; }

        public Guid PublicacaoId { get; set; }
        public PublicacaoDto Publicacao { get; set; }
        
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
