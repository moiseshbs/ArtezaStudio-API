using ArtezaStudio.Application.Dtos.Publicacao;
using ArtezaStudio.Application.Dtos.Usuario;

namespace ArtezaStudio.Application.Dtos.Curtida
{
    public class CurtidaDto
    {
        public long Id { get; set; }
        public DateTime DataCurtida { get; set; }

        public long PublicacaoId { get; set; }
        public PublicacaoDto Publicacao { get; set; }

        public long UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
