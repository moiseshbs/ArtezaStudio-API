using ArtezaStudio.Api.Entities;

namespace ArtezaStudio.Api.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ListarAsync();
        Task<Usuario> ObterPorIdAsync(Guid id);
        Task<Usuario> ObterPorEmailAsync(string email);
        Task<Usuario> ObterPorUsernameAsync(string username);
        Task<Usuario> CriarAsync(Usuario usuario);
        Task<Usuario> AtualizarAsync(Usuario usuario);
        Task<bool> ExcluirAsync(Guid id);
        Task<bool> ExisteEmailAsync(string email);
        Task<bool> ExisteUsernameAsync(string username);
    }
}
