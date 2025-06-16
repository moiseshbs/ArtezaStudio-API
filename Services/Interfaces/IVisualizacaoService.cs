using ArtezaStudio.Api.Dtos.Visualizacao;

namespace ArtezaStudio.Api.Services.Interfaces
{
    public interface IVisualizacaoService
    {
        Task<IEnumerable<VisualizacaoDto>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<VisualizacaoDto> CriarAsync(VisualizacaoFiltroDto visualizacaoDto);
    }
}
