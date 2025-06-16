using ArtezaStudio.Api.Data;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Api.Repositories
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
            _context.visualizacoes.Add(visualizacao);
            await _context.SaveChangesAsync();

            return visualizacao;
        }

        public async Task<IEnumerable<Visualizacao>> ListarPorPublicacaoIdAsync(Guid publicacaoId)
        {
            return await _context.visualizacoes
                .Where(v => v.PublicacaoId == publicacaoId)
                .ToListAsync();
        }
    }
}
