namespace ArtezaStudio.Api.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<PublicacaoTag> PublicacaoTags { get; set; } = new List<PublicacaoTag>();
    }
}
