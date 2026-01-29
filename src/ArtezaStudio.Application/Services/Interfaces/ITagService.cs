using ArtezaStudio.Application.Dtos.Tag;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagDto>> ListarAsync();
        Task<IEnumerable<TagDto>> ListarPorNomeAsync(string tagNome);
        Task<TagDto> CriarAsync(TagFiltroDto tagFiltroDto);
        Task<bool> ExcluirAsync(long id);
    }
}
