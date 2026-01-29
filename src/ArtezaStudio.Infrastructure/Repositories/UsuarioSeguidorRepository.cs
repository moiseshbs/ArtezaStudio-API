using ArtezaStudio.Infrastructure.Data;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Infrastructure.Repositories
{
    public class UsuarioSeguidorRepository : IUsuarioSeguidorRepository
    {
        private readonly ArtezaContext _context;
        public UsuarioSeguidorRepository(ArtezaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioSeguidor>> ListarSeguidoresAsync(Guid usuarioId)
        {
            return await _context.usuarioSeguidores
                .Where(us => us.SeguidoId == usuarioId)
                .Include(us => us.Seguidor)
                .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioSeguidor>> ListarSeguindoAsync(Guid usuarioId)
        {
            return await _context.usuarioSeguidores
                .Where(us => us.SeguidorId == usuarioId)
                .Include(us => us.Seguido)
                .ToListAsync();
        }

        public async Task<UsuarioSeguidor> SeguirUsuarioAsync(UsuarioSeguidor usuarioSeguidor)
        {
            _context.usuarioSeguidores.Add(usuarioSeguidor);
            await _context.SaveChangesAsync();
            return usuarioSeguidor;
        }

        public async Task<bool> UnfollowAsync(Guid seguidorId, Guid seguidoId)
        {
            return await _context.usuarioSeguidores
                .Where(us => us.SeguidorId == seguidorId && us.SeguidoId == seguidoId)
                .ExecuteDeleteAsync() > 0;
        }
    }
}
