namespace ArtezaStudio.Api.Dtos.Publicacao
{
    public class PublicacaoFiltroDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
