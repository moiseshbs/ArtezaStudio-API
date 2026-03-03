using ArtezaStudio.Application.Dtos.Usuario;
using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface IUsuarioSeguidorService
    {
        Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguidoresAsync(long usuarioId);
        Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguindoAsync(long usuarioId);
        Task<UsuarioSeguidorDto> SeguirUsuarioAsync(SeguirUsuarioDto seguirUsuarioDto);
        Task<bool> UnfollowAsync(SeguirUsuarioDto seguirUsuarioDto);
    }
}
