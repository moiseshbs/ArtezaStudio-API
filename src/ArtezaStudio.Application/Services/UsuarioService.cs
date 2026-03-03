using ArtezaStudio.Application.Dtos.Usuario;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Interfaces;
using ArtezaStudio.Application.Services.Interfaces;
using AutoMapper;

namespace ArtezaStudio.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaHashService _senhaHashService;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, ISenhaHashService senhaHashService, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _senhaHashService = senhaHashService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> ListarAsync()
        {
            var usuarios = await _usuarioRepository.ListarAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto> ObterPorIdAsync(long id)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> ObterPorEmailAsync(string email)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(email);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> ObterPorUsernameAsync(string username)
        {
            var usuario = await _usuarioRepository.ObterPorUsernameAsync(username);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> CriarAsync(UsuarioFiltroDto usuarioFiltroDto)
        {
            var entity = _mapper.Map<Usuario>(usuarioFiltroDto);
            entity.Senha = _senhaHashService.HashSenha(usuarioFiltroDto.Senha);

            var novoUsuario = await _usuarioRepository.CriarAsync(entity);
            return _mapper.Map<UsuarioDto>(novoUsuario);
        }

        public async Task<UsuarioDto> AtualizarAsync(UsuarioFiltroDto usuarioFiltroDto)
        {
            var entity = _mapper.Map<Usuario>(usuarioFiltroDto);
            var usuarioAtualizado = await _usuarioRepository.AtualizarAsync(entity);
            return _mapper.Map<UsuarioDto>(usuarioAtualizado);
        }

        public async Task<bool> ExcluirAsync(long id)
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
