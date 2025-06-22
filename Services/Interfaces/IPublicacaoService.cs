using ArtezaStudio.Api.Dtos.Publicacao;

namespace ArtezaStudio.Api.Services.Interfaces
{
    public interface IPublicacaoService
    {
        Task<IEnumerable<PublicacaoDto>> ListarAsync();
        Task<IEnumerable<PublicacaoDto>> ListarPorUsuarioIdAsync(Guid usuarioId);
        Task<IEnumerable<PublicacaoDto>> ListarPorTagIdAsync(Guid tagId);
        Task<IEnumerable<PublicacaoDto>> ListarPorTermoAsync(string termo);
        Task<PublicacaoDto> CriarAsync(PublicacaoFiltroDto publicacaoFiltroDto);
        Task<PublicacaoDto> ObterPorIdAsync(Guid id);
        Task<bool> ExcluirAsync(Guid id);
        Task<PublicacaoDto> AtualizarAsync(PublicacaoFiltroDto publicacaoFiltroDto);
    }
}
