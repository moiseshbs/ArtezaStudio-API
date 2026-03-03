using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Domain.Interfaces
{
    public interface IComentarioRepository
    {
        Task<IEnumerable<Comentario>> ListarPorPublicacaoIdAsync(long publicacaoId);
        Task<Comentario> CriarAsync(Comentario comentario);
        Task<Comentario> AtualizarAsync(Comentario comentario);
        Task<bool> ExcluirAsync(long id);
    }
}
