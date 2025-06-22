using ArtezaStudio.Api.Data;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Api.Repositories
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
            tag.Id = Guid.NewGuid();
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<bool> ExcluirAsync(Guid id)
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
