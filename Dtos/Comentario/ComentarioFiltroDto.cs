namespace ArtezaStudio.Api.Dtos.Comentario
{
    public class ComentarioFiltroDto
    {
        public Guid Id { get; set; }
        public string Conteudo { get; set; }

        public Guid PublicacaoId { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
