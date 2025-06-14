using ArtezaStudio.Api.Dtos.Usuario;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Repositories.Interfaces;
using ArtezaStudio.Api.Services.Interfaces;
using AutoMapper;

namespace ArtezaStudio.Api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UsuarioDto>> ListarAsync()
        {
            var usuarios = await _usuarioRepository.ListarAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }
        public async Task<UsuarioDto> ObterPorIdAsync(Guid id)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            return _mapper.Map<UsuarioDto>(usuario);
        }
        public async Task<UsuarioDto> ObterPorEmailAsync(string email)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(email);
            return _mapper.Map<UsuarioDto>(usuario);
        }
        public async Task<UsuarioDto> ObterPorUsernameAsync(string email)
        {
            var usuario = await _usuarioRepository.ObterPorUsernameAsync(email);
            return _mapper.Map<UsuarioDto>(usuario);
        }
        public async Task<UsuarioDto> CriarAsync(UsuarioFiltroDto usuarioFiltroDto)
        {
            var entity = _mapper.Map<Usuario>(usuarioFiltroDto);
            var novoUsuario = await _usuarioRepository.CriarAsync(entity);
            return _mapper.Map<UsuarioDto>(novoUsuario);
        }
        public async Task<UsuarioDto> AtualizarAsync(UsuarioFiltroDto usuarioFiltroDto)
        {
            var entity = _mapper.Map<Usuario>(usuarioFiltroDto);
            var usuarioAtualizado = await _usuarioRepository.AtualizarAsync(entity);
            return _mapper.Map<UsuarioDto>(usuarioAtualizado);
        }
        public async Task<bool> ExcluirAsync(Guid id)
        {
            return await _usuarioRepository.ExcluirAsync(id);
        }
        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _usuarioRepository.ExisteEmailAsync(email);
        }
        public async Task<bool> ExisteUsernameAsync(string username)
        {
            return await _usuarioRepository.ExisteUsernameAsync(username);
        }
    }
}
