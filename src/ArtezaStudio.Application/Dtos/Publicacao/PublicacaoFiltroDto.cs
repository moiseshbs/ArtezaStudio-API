namespace ArtezaStudio.Application.Dtos.Publicacao
{
    public class PublicacaoFiltroDto
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }

        public long UsuarioId { get; set; }

        public List<long> TagIds { get; set; }
    }
}
