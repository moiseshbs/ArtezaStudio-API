using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Domain.Interfaces
{
    public interface IUsuarioSeguidorRepository
    {
        Task<IEnumerable<UsuarioSeguidor>> ListarSeguidoresAsync(Guid usuarioId);
        Task<IEnumerable<UsuarioSeguidor>> ListarSeguindoAsync(Guid usuarioId);
        Task<UsuarioSeguidor> SeguirUsuarioAsync(UsuarioSeguidor usuarioSeguidor);
        Task<bool> UnfollowAsync(Guid seguidorId, Guid seguidoId);
    }
}
