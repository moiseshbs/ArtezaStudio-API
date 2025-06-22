namespace ArtezaStudio.Api.Entities
{
    public class PublicacaoTag
    {
        public Guid PublicacaoId { get; set; }
        public Publicacao Publicacao { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
