using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ListarAsync();
        Task<Usuario> ObterPorIdAsync(long id);
        Task<Usuario> ObterPorEmailAsync(string email);
        Task<Usuario> ObterPorUsernameAsync(string username);
        Task<Usuario> CriarAsync(Usuario usuario);
        Task<Usuario> AtualizarAsync(Usuario usuario);
        Task<bool> ExcluirAsync(long id);
        Task<bool> ExisteEmailAsync(string email);
        Task<bool> ExisteUsernameAsync(string username);
    }
}
