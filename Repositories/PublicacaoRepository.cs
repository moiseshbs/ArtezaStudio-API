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
            return await _context.publicacoes
                .Include(p => p.Usuario)
                .Include(p => p.Comentarios)
                .Include(p => p.Curtidas)
                .ToListAsync();
        }

        public async Task<Publicacao> CriarAsync(Publicacao publicacao)
        {
            publicacao.Id = Guid.NewGuid();
            _context.publicacoes.Add(publicacao);
            await _context.SaveChangesAsync();
            return publicacao;
        }

        public async Task<Publicacao> ObterPorIdAsync(Guid id)
        {
            return await _context.publicacoes
                .Include(p => p.Usuario)
                .Include(p => p.Comentarios)
                .Include(p => p.Curtidas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            return await _context.publicacoes.Where(p => p.Id == id).ExecuteDeleteAsync() > 0;
        }

        public async Task<Publicacao> AtualizarAsync(Publicacao publicacao)
        {
            var procuraPublicacao = _context.publicacoes.Find(publicacao.Id);
            if (procuraPublicacao == null)
                throw new KeyNotFoundException("Publicação não encontrada.");

            procuraPublicacao.Titulo = publicacao.Titulo;
            procuraPublicacao.Descricao = publicacao.Descricao;

            return await _context.SaveChangesAsync().ContinueWith(t => procuraPublicacao);
        }
    }
}
