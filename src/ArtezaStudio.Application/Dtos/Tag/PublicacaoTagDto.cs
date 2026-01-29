using ArtezaStudio.Application.Dtos.Publicacao;

namespace ArtezaStudio.Application.Dtos.Tag
{
    public class PublicacaoTagDto
    {
        public Guid PublicacaoId { get; set; }
        public PublicacaoDto Publicacao { get; set; }
        public Guid TagId { get; set; }
        public TagDto Tag { get; set; }
    }
}
