using ArtezaStudio.Api.Data;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtezaStudio.Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ArtezaContext _context;
        public UsuarioRepository(ArtezaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> ListarAsync()
        {
            return await _context.usuarios.ToListAsync();
        }

        public async Task<Usuario> CriarAsync(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            _context.usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> ObterPorIdAsync(Guid id)
        {
            return await _context.usuarios.FindAsync(id);
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _context.usuarios
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<Usuario> ObterPorUsernameAsync(string username)
        {
            return await _context.usuarios
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<Usuario> AtualizarAsync(Usuario usuario)
        {
            var procuraUsuario = _context.usuarios.Find(usuario.Id);
            if (procuraUsuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            procuraUsuario.Nome = usuario.Nome;
            procuraUsuario.Username = usuario.Username;
            procuraUsuario.Email = usuario.Email;
            procuraUsuario.Senha = usuario.Senha;
            procuraUsuario.ImagemPerfilUrl = usuario.ImagemPerfilUrl;
            procuraUsuario.IsAtivo = usuario.IsAtivo;

            return await _context.SaveChangesAsync().ContinueWith(t => procuraUsuario);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            return await _context.usuarios.Where(u => u.Id == id).ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _context.usuarios.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> ExisteUsernameAsync(string username)
        {   
            return await _context.usuarios.AnyAsync(u => u.Username == username);
        }
    }
}
