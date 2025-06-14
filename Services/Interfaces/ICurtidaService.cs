using ArtezaStudio.Api.Dtos.Curtida;

namespace ArtezaStudio.Api.Services.Interfaces
{
    public interface ICurtidaService
    {
        Task<IEnumerable<CurtidaDto>> ListarPorPublicacaoIdAsync(Guid publicacaoId);
        Task<CurtidaDto> CriarAsync(CurtidaFiltroDto curtidaDto);
        Task<bool> ExcluirAsync(Guid id);
    }
}
