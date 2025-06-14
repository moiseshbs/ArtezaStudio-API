using ArtezaStudio.Api.Entities;

namespace ArtezaStudio.Api.Repositories.Interfaces
{
    public interface IComentarioRepository
    {
        Task<IEnumerable<Comentario>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<Comentario> CriarAsync(Comentario comentario);
        Task<Comentario> AtualizarAsync(Comentario comentario);
        Task<bool> ExcluirAsync(Guid id);
    }
}
