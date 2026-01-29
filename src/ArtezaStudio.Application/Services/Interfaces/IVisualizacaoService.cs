using ArtezaStudio.Application.Dtos.Visualizacao;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface IVisualizacaoService
    {
        Task<IEnumerable<VisualizacaoDto>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<VisualizacaoDto> CriarAsync(VisualizacaoFiltroDto visualizacaoDto);
    }
}
