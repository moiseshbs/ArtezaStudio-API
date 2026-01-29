using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Domain.Interfaces
{
    public interface IComentarioRepository
    {
        Task<IEnumerable<Comentario>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<Comentario> CriarAsync(Comentario comentario);
        Task<Comentario> AtualizarAsync(Comentario comentario);
        Task<bool> ExcluirAsync(Guid id);
    }
}
