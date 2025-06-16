using ArtezaStudio.Api.Entities;

namespace ArtezaStudio.Api.Repositories.Interfaces
{
    public interface IVisualizacaoRepository
    {
        Task<IEnumerable<Visualizacao>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<Visualizacao> CriarAsync(Visualizacao visualizacao);
    }
}
