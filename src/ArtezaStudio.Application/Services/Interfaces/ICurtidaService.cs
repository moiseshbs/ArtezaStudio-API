using ArtezaStudio.Application.Dtos.Curtida;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface ICurtidaService
    {
        Task<IEnumerable<CurtidaDto>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<CurtidaDto> CriarAsync(CurtidaFiltroDto curtidaDto);
        Task<bool> ExcluirAsync(Guid id);
    }
}
