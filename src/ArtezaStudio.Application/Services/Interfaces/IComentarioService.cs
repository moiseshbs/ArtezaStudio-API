using ArtezaStudio.Application.Dtos.Comentario;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface IComentarioService
    {
        Task<IEnumerable<ComentarioDto>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<ComentarioDto> CriarAsync(ComentarioFiltroDto comentarioFiltroDto);
        Task<ComentarioDto> AtualizarAsync(ComentarioFiltroDto comentarioFiltroDto);
        Task<bool> ExcluirAsync(Guid id);
    }
}
