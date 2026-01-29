using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Domain.Interfaces
{
    public interface ICurtidaRepository
    {
        Task<IEnumerable<Curtida>> ListarPorPublicacaoIdAsync(long publicacaoId);
        Task<Curtida> CriarAsync(Curtida curtida);
        Task<bool> ExcluirAsync(long id);
    }
}
