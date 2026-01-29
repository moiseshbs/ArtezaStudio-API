using ArtezaStudio.Infrastructure.Data;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Infrastructure.Repositories
{
    public class VisualizacaoRepository : IVisualizacaoRepository
    {
        private readonly ArtezaContext _context;
        public VisualizacaoRepository(ArtezaContext context)
        {
            _context = context;
        }

        public async Task<Visualizacao> CriarAsync(Visualizacao visualizacao)
        {
            visualizacao.Id = Guid.NewGuid();
            _context.Visualizacoes.Add(visualizacao);
            await _context.SaveChangesAsync();

            return visualizacao;
        }

        public async Task<IEnumerable<Visualizacao>> ListarPorPublicacaoIdAsync(Guid publicacaoId)
        {
            return await _context.Visualizacoes
                .Where(v => v.PublicacaoId == publicacaoId)
                .ToListAsync();
        }
    }
}
