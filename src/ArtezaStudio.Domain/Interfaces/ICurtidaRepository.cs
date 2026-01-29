using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Domain.Interfaces
{
    public interface ICurtidaRepository
    {
        Task<IEnumerable<Curtida>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<Curtida> CriarAsync(Curtida curtida);
        Task<bool> ExcluirAsync(Guid id);
    }
}
