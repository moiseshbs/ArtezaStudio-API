using ArtezaStudio.Api.Dtos.Tag;

namespace ArtezaStudio.Api.Services.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagDto>> ListarAsync();
        Task<IEnumerable<TagDto>> ListarPorNomeAsync(string tagNome);
        Task<TagDto> CriarAsync(TagFiltroDto tagFiltroDto);
        Task<bool> ExcluirAsync(Guid id);
    }
}
