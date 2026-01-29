using ArtezaStudio.Application.Dtos.Publicacao;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface IPublicacaoService
    {
        Task<IEnumerable<PublicacaoDto>> ListarAsync();
        Task<IEnumerable<PublicacaoDto>> ListarPorUsuarioIdAsync(long usuarioId);
        Task<IEnumerable<PublicacaoDto>> ListarPorTagIdAsync(long tagId);
        Task<IEnumerable<PublicacaoDto>> ListarPorTermoAsync(string termo);
        Task<PublicacaoDto> CriarAsync(PublicacaoFiltroDto publicacaoFiltroDto);
        Task<PublicacaoDto> ObterPorIdAsync(long id);
        Task<bool> ExcluirAsync(long id);
        Task<PublicacaoDto> AtualizarAsync(PublicacaoFiltroDto publicacaoFiltroDto);
    }
}
