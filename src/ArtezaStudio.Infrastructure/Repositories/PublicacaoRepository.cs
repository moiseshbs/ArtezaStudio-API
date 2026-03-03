using ArtezaStudio.Infrastructure.Data;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Infrastructure.Repositories
{
    public class PublicacaoRepository : IPublicacaoRepository
    {
        private readonly ArtezaContext _context;

        public PublicacaoRepository(ArtezaContext context)
        {
            _context = context;
        }

        private IQueryable<Publicacao> GetBaseQuery()
        {
            return _context.Publicacoes
                .AsNoTracking()
                .AsSplitQuery()
                .Include(p => p.Usuario)
                .Include(p => p.Comentarios)
                .Include(p => p.Curtidas)
                .Include(p => p.Visualizacoes)
                .Include(p => p.PublicacaoTags)
                    .ThenInclude(pt => pt.Tag)
                .OrderByDescending(p => p.DataPublicacao);
        }

        public async Task<(IEnumerable<Publicacao> Items, int TotalCount)> ListarAsync(int page, int pageSize)
        {
            var query = GetBaseQuery();

            var totalCount = await _context.Publicacoes.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<(IEnumerable<Publicacao> Items, int TotalCount)> ListarPorUsuarioIdAsync(long usuarioId, int page, int pageSize)
        {
            var query = GetBaseQuery().Where(p => p.UsuarioId == usuarioId);

            var totalCount = await _context.Publicacoes.CountAsync(p => p.UsuarioId == usuarioId);
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<(IEnumerable<Publicacao> Items, int TotalCount)> ListarPorTagIdAsync(long tagId, int page, int pageSize)
        {
            var query = GetBaseQuery().Where(p => p.PublicacaoTags.Any(pt => pt.TagId == tagId));

            var totalCount = await _context.Publicacoes.CountAsync(p => p.PublicacaoTags.Any(pt => pt.TagId == tagId));
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<(IEnumerable<Publicacao> Items, int TotalCount)> ListarPorTermoAsync(string termo, int page, int pageSize)
        {
            var termoLower = termo.ToLower();
            var query = GetBaseQuery()
                .Where(p => p.Titulo.ToLower().Contains(termoLower) || p.Descricao.ToLower().Contains(termoLower));

            var totalCount = await _context.Publicacoes
                .CountAsync(p => p.Titulo.ToLower().Contains(termoLower) || p.Descricao.ToLower().Contains(termoLower));
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<Publicacao> CriarAsync(Publicacao publicacao)
        {
            _context.Publicacoes.Add(publicacao);
            await _context.SaveChangesAsync();
            return publicacao;
        }

        public async Task<Publicacao?> ObterPorIdAsync(long id)
        {
            return await GetBaseQuery().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> ExcluirAsync(long id)
        {
            return await _context.Publicacoes.Where(p => p.Id == id).ExecuteDeleteAsync() > 0;
        }

        public async Task<Publicacao> AtualizarAsync(Publicacao publicacao)
        {
            var procuraPublicacao = await _context.Publicacoes.FindAsync(publicacao.Id) 
                ?? throw new KeyNotFoundException("Publicação não encontrada.");

            procuraPublicacao.Titulo = publicacao.Titulo;
            procuraPublicacao.Descricao = publicacao.Descricao;

            await _context.SaveChangesAsync();
            return procuraPublicacao;
        }

        public async Task AdicionarPublicacaoTagAsync(PublicacaoTag publicacaoTag)
        {
            _context.PublicacaoTags.Add(publicacaoTag);
            await _context.SaveChangesAsync();
        }
    }
}