using ArtezaStudio.Api.Dtos.Usuario;
using ArtezaStudio.Api.Entities;

namespace ArtezaStudio.Api.Repositories.Interfaces
{
    public interface IUsuarioSeguidorRepository
    {
        Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguidoresAsync(Guid usuarioId);
        Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguindoAsync(Guid usuarioId);
        Task<UsuarioSeguidor> SeguirUsuarioAsync(UsuarioSeguidor seguirUsuarioDto);
        Task<bool> UnfollowAsync(SeguirUsuarioDto seguirUsuarioDto);
    }
}
