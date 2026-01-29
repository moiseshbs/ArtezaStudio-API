using ArtezaStudio.Application.Dtos.Usuario;
using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface IUsuarioSeguidorService
    {
        Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguidoresAsync(Guid usuarioId);
        Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguindoAsync(Guid usuarioId);
        Task<UsuarioSeguidorDto> SeguirUsuarioAsync(SeguirUsuarioDto seguirUsuarioDto);
        Task<bool> UnfollowAsync(SeguirUsuarioDto seguirUsuarioDto);
    }
}
