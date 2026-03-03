namespace ArtezaStudio.Domain.Entities
{
    public class PublicacaoTag
    {
        public long PublicacaoId { get; set; }
        public Publicacao Publicacao { get; set; }

        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}