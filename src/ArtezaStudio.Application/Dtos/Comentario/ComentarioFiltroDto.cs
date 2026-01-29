namespace ArtezaStudio.Application.Dtos.Comentario
{
    public class ComentarioFiltroDto
    {
        public long Id { get; set; }
        public string Conteudo { get; set; }

        public long PublicacaoId { get; set; }

        public long UsuarioId { get; set; }
    }
}
