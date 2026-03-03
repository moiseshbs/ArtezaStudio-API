using ArtezaStudio.Application.Dtos.Publicacao;

namespace ArtezaStudio.Application.Dtos.Tag
{
    public class PublicacaoTagDto
    {
        public long PublicacaoId { get; set; }
        public PublicacaoDto Publicacao { get; set; }
        public long TagId { get; set; }
        public TagDto Tag { get; set; }
    }
}
