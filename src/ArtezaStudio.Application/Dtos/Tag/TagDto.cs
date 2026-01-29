namespace ArtezaStudio.Application.Dtos.Tag
{
    public class TagDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public ICollection<PublicacaoTagDto>? PublicacaoTags { get; set; } = new List<PublicacaoTagDto>();
    }
}
