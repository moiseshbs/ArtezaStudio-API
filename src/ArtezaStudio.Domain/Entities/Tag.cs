namespace ArtezaStudio.Domain.Entities
{
    public class Tag
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<PublicacaoTag> PublicacaoTags { get; set; } = new List<PublicacaoTag>();
    }
}