namespace ArtezaStudio.Api.Dtos.Tag
{
    public class PublicacaoTagFiltroDto
    {
        public Guid PublicacaoId { get; set; }
        public List<Guid> TagId { get; set; }
    }
}
