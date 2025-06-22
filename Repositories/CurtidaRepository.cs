using ArtezaStudio.Api.Data;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Api.Repositories
{
    public class CurtidaRepository : ICurtidaRepository
    {
        private readonly ArtezaContext _context;

        public CurtidaRepository(ArtezaContext context)
        {
            _context = context;
        }

        public async Task<Curtida> CriarAsync(Curtida curtida)
        {
            curtida.Id = Guid.NewGuid();
            _context.Curtidas.Add(curtida);
            await _context.SaveChangesAsync();

            return curtida;
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            return await _context.Curtidas.Where(c => c.Id == id).ExecuteDeleteAsync() > 0;
        }

        public async Task<IEnumerable<Curtida>> ListarPorPublicacaoIdAsync(Guid publicacaoId)
        {
            return await _context.Curtidas
                .Where(c => c.PublicacaoId == publicacaoId)
                .ToListAsync();
        }
    }
}
