using ArtezaStudio.Application.Dtos.Publicacao;
using ArtezaStudio.Application.Dtos.Usuario;

namespace ArtezaStudio.Application.Dtos.Curtida
{
    public class CurtidaDto
    {
        public Guid Id { get; set; }
        public DateTime DataCurtida { get; set; }

        public Guid PublicacaoId { get; set; }
        public PublicacaoDto Publicacao { get; set; }

        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
