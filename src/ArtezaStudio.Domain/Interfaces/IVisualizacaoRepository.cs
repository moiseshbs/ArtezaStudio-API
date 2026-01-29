using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Domain.Interfaces
{
    public interface IVisualizacaoRepository
    {
        Task<IEnumerable<Visualizacao>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<Visualizacao> CriarAsync(Visualizacao visualizacao);
    }
}
