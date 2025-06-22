using ArtezaStudio.Api.Dtos.Publicacao;

namespace ArtezaStudio.Api.Dtos.Tag
{
    public class PublicacaoTagDto
    {
        public Guid PublicacaoId { get; set; }
        public PublicacaoDto Publicacao { get; set; }
        public Guid TagId { get; set; }
        public TagDto Tag { get; set; }
    }
}
