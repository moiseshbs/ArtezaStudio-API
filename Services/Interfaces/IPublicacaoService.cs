using ArtezaStudio.Api.Dtos.Publicacao;

namespace ArtezaStudio.Api.Services.Interfaces
{
    public interface IPublicacaoService
    {
        Task<IEnumerable<PublicacaoDto>> ListarAsync();
        Task<PublicacaoDto> CriarAsync(PublicacaoFiltroDto publicacaoFiltroDto);
        Task<PublicacaoDto> ObterPorIdAsync(Guid id);
        Task<bool> ExcluirAsync(Guid id);
        Task<PublicacaoDto> AtualizarAsync(PublicacaoFiltroDto publicacaoFiltroDto);
    }
}
