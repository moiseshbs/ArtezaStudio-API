namespace ArtezaStudio.Api.Dtos.Tag
{
    public class TagDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ICollection<PublicacaoTagDto>? PublicacaoTags { get; set; } = new List<PublicacaoTagDto>();
    }
}
