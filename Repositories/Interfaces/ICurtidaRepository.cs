using ArtezaStudio.Api.Entities;

namespace ArtezaStudio.Api.Repositories.Interfaces
{
    public interface ICurtidaRepository
    {
        Task<IEnumerable<Curtida>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<Curtida> CriarAsync(Curtida curtida);
        Task<bool> ExcluirAsync(Guid id);
    }
}
