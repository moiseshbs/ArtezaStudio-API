using ArtezaStudio.Api.Entities;

namespace ArtezaStudio.Api.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> ListarAsync();
        Task<IEnumerable<Tag>> ListarPorNomeAsync(string tagNome);
        Task<Tag> CriarAsync(Tag tag);
        Task<bool> ExcluirAsync(Guid id);
    }
}
