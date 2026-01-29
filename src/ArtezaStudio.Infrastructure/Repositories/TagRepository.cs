using ArtezaStudio.Infrastructure.Data;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ArtezaContext _context;

        public TagRepository(ArtezaContext context)
        {
            _context = context;
        }

        public async Task<Tag> CriarAsync(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<bool> ExcluirAsync(long id)
        {
            return await _context.Tags.Where(t => t.Id == id).ExecuteDeleteAsync() > 0;
        }

        public async Task<IEnumerable<Tag>> ListarAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<IEnumerable<Tag>> ListarPorNomeAsync(string tagNome)
        {
            return await _context.Tags
                .Where(t => t.Nome.ToLower().Contains(tagNome.ToLower()))
                .ToListAsync();
        }
    }
}
