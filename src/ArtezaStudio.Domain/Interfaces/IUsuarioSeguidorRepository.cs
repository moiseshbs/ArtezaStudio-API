using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Domain.Interfaces
{
    public interface IUsuarioSeguidorRepository
    {
        Task<IEnumerable<UsuarioSeguidor>> ListarSeguidoresAsync(long usuarioId);
        Task<IEnumerable<UsuarioSeguidor>> ListarSeguindoAsync(long usuarioId);
        Task<UsuarioSeguidor> SeguirUsuarioAsync(UsuarioSeguidor usuarioSeguidor);
        Task<bool> UnfollowAsync(long seguidorId, long seguidoId);
    }
}
