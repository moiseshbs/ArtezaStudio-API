using ArtezaStudio.Api.Data;
using ArtezaStudio.Api.Dtos.Usuario;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Api.Repositories
{
    public class UsuarioSeguidorRepository : IUsuarioSeguidorRepository
    {
        private readonly ArtezaContext _context;
        public UsuarioSeguidorRepository(ArtezaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguidoresAsync(Guid usuarioId)
        {
            return await _context.usuarioSeguidores
                .Where(us => us.SeguidoId == usuarioId)
                .Select(us => new UsuarioSeguidorDto
                {
                    SeguidorId = us.SeguidorId,
                    SeguidoId = us.SeguidoId
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguindoAsync(Guid usuarioId)
        {
            return await _context.usuarioSeguidores
                .Where(us => us.SeguidorId == usuarioId)
                .Select(us => new UsuarioSeguidorDto
                {
                    SeguidorId = us.SeguidorId,
                    SeguidoId = us.SeguidoId
                })
                .ToListAsync();
        }

        public async Task<UsuarioSeguidor> SeguirUsuarioAsync(UsuarioSeguidor usuarioSeguidor)
        {
            _context.usuarioSeguidores.Add(usuarioSeguidor);
            await _context.SaveChangesAsync();
            return usuarioSeguidor;
        }

        public async Task<bool> UnfollowAsync(SeguirUsuarioDto seguirUsuarioDto)
        {
            return await _context.usuarioSeguidores
                .Where(us => us.SeguidorId == seguirUsuarioDto.SeguidorId && us.SeguidoId == seguirUsuarioDto.SeguidoId)
                .ExecuteDeleteAsync() > 0;
        }
    }
}
