using ArtezaStudio.Api.Dtos.Comentario;

namespace ArtezaStudio.Api.Services.Interfaces
{
    public interface IComentarioService
    {
        Task<IEnumerable<ComentarioDto>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<ComentarioDto> CriarAsync(ComentarioFiltroDto comentarioFiltroDto);
        Task<ComentarioDto> AtualizarAsync(ComentarioFiltroDto comentarioFiltroDto);
        Task<bool> ExcluirAsync(Guid id);
    }
}
