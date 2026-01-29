using ArtezaStudio.Infrastructure.Data;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Infrastructure.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly ArtezaContext _context;

        public ComentarioRepository(ArtezaContext context)
        {
            _context = context;
        }

        public async Task<Comentario> AtualizarAsync(Comentario comentario)
        {
            var procuraComentario = _context.Comentarios.Find(comentario.Id);
            if (procuraComentario == null)
                throw new KeyNotFoundException("Comentário não encontrado.");

            procuraComentario.Conteudo = comentario.Conteudo;
            procuraComentario.DataComentario = comentario.DataComentario;

            return await _context.SaveChangesAsync().ContinueWith(t => procuraComentario);
        }

        public async Task<Comentario> CriarAsync(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return comentario;
        }

        public async Task<bool> ExcluirAsync(long id)
        {
            return await _context.Comentarios.Where(c => c.Id == id).ExecuteDeleteAsync() > 0;
        }

        public async Task<IEnumerable<Comentario>> ListarPorPublicacaoIdAsync(long publicacaoId)
        {
            return await _context.Comentarios
                .Where(c => c.PublicacaoId == publicacaoId)
                .ToListAsync();
        }
    }
}
