using ArtezaStudio.Api.Dtos.Publicacao;
using ArtezaStudio.Api.Dtos.Usuario;

namespace ArtezaStudio.Api.Dtos.Curtida
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
