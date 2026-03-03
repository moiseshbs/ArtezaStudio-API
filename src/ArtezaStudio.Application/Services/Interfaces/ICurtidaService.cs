using ArtezaStudio.Application.Dtos.Curtida;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface ICurtidaService
    {
        Task<IEnumerable<CurtidaDto>> ListarPorPublicacaoIdAsync(long publicacaoId);
        Task<CurtidaDto> CriarAsync(CurtidaFiltroDto curtidaDto);
        Task<bool> ExcluirAsync(long id);
    }
}
