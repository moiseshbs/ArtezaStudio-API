using ArtezaStudio.Api.Dtos.Usuario;
using ArtezaStudio.Api.Entities;

namespace ArtezaStudio.Api.Services.Interfaces
{
    public interface IUsuarioSeguidorService
    {
        Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguidoresAsync(Guid usuarioId);
        Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguindoAsync(Guid usuarioId);
        Task<UsuarioSeguidorDto> SeguirUsuarioAsync(SeguirUsuarioDto seguirUsuarioDto);
        Task<bool> UnfollowAsync(SeguirUsuarioDto seguirUsuarioDto);
    }
}
