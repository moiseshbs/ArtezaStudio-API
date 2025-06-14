using ArtezaStudio.Api.Dtos.Usuario;

namespace ArtezaStudio.Api.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> ListarAsync();
        Task<UsuarioDto> ObterPorIdAsync(Guid id);
        Task<UsuarioDto> ObterPorEmailAsync(string email);
        Task<UsuarioDto> ObterPorUsernameAsync(string username);
        Task<UsuarioDto> CriarAsync(UsuarioFiltroDto usuarioFiltroDto);
        Task<UsuarioDto> AtualizarAsync(UsuarioFiltroDto usuarioFiltroDto);
        Task<bool> ExcluirAsync(Guid id);
        Task<bool> ExisteEmailAsync(string email);
        Task<bool> ExisteUsernameAsync(string username);
    }
}
