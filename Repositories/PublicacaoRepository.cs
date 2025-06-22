using ArtezaStudio.Api.Data;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Api.Repositories
{
    public class PublicacaoRepository : IPublicacaoRepository
    {
        private readonly ArtezaContext _context;

        public PublicacaoRepository(ArtezaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publicacao>> ListarAsync()
        {
            return await _context.Publicacoes
                .Include(p => p.Usuario)
                .Include(p => p.Comentarios)
                .Include(p => p.Curtidas)
                .Include(p => p.Visualizacoes)
                .Include(p => p.PublicacaoTags)
                    .ThenInclude(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<Publicacao>> ListarPorUsuarioIdAsync(Guid usuarioId)
        {
            return await _context.Publicacoes
                .Where(p => p.UsuarioId == usuarioId)
                .Include(p => p.Usuario)
                .Include(p => p.Comentarios)
                .Include(p => p.Curtidas)
                .Include(p => p.Visualizacoes)
                .Include(p => p.PublicacaoTags)
                    .ThenInclude(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<Publicacao>> ListarPorTagIdAsync(Guid tagId)
        {
            return await _context.Publicacoes
                .Where(p => p.PublicacaoTags.Any(pt => pt.TagId == tagId))
                .Include(p => p.Usuario)
                .Include(p => p.Comentarios)
                .Include(p => p.Curtidas)
                .Include(p => p.Visualizacoes)
                .Include(p => p.PublicacaoTags)
                    .ThenInclude(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<Publicacao>> ListarPorTermoAsync(string termo)
        {
            return await _context.Publicacoes
                .Where(p => p.Titulo.ToLower().Contains(termo.ToLower()) || p.Descricao.ToLower().Contains(termo.ToLower()))
                .Include(p => p.Usuario)
                .Include(p => p.Comentarios)
                .Include(p => p.Curtidas)
                .Include(p => p.Visualizacoes)
                .Include(p => p.PublicacaoTags)
                    .ThenInclude(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<Publicacao> CriarAsync(Publicacao publicacao)
        {
            publicacao.Id = Guid.NewGuid();
            _context.Publicacoes.Add(publicacao);
            await _context.SaveChangesAsync();
            return publicacao;
        }

        public async Task<Publicacao> ObterPorIdAsync(Guid id)
        {
            return await _context.Publicacoes
                .Include(p => p.Usuario)
                .Include(p => p.Comentarios)
                .Include(p => p.Curtidas)
                .Include(p => p.Visualizacoes)
                .Include(p => p.PublicacaoTags)
                    .ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            return await _context.Publicacoes.Where(p => p.Id == id).ExecuteDeleteAsync() > 0;
        }

        public async Task<Publicacao> AtualizarAsync(Publicacao publicacao)
        {
            var procuraPublicacao = _context.Publicacoes.Find(publicacao.Id);
            if (procuraPublicacao == null)
                throw new KeyNotFoundException("Publicação não encontrada.");

            procuraPublicacao.Titulo = publicacao.Titulo;
            procuraPublicacao.Descricao = publicacao.Descricao;

            return await _context.SaveChangesAsync().ContinueWith(t => procuraPublicacao);
        }

        public async Task AdicionarPublicacaoTagAsync(PublicacaoTag publicacaoTag)
        {
            _context.PublicacaoTags.Add(publicacaoTag);
            await _context.SaveChangesAsync();
        }
    }
}
