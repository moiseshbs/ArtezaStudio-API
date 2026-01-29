using ArtezaStudio.Application.Dtos.Auth;
using ArtezaStudio.Application.Dtos.Usuario;
using ArtezaStudio.Application.Services.Interfaces;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Interfaces;
using AutoMapper;

namespace ArtezaStudio.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaHashService _senhaHashService;
        private readonly IMapper _mapper;

        public AuthService(IUsuarioRepository usuarioRepository, ISenhaHashService senhaHashService, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _senhaHashService = senhaHashService;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(loginRequest.Email);

            if (usuario == null)
                throw new UnauthorizedAccessException("Email ou senha inválidos.");

            var senhaValida = _senhaHashService.VerificarSenha(loginRequest.Senha, usuario.Senha);
            
            if (!senhaValida)
                throw new UnauthorizedAccessException("Email ou senha inválidos.");

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return new LoginResponseDto
            {
                Usuario = usuarioDto,
                Token = "temp-token", // Substituir por JWT real depois
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };
        }

        public async Task<LoginResponseDto> RegistrarAsync(RegistroRequestDto registroRequest)
        {
            var emailExiste = await _usuarioRepository.ExisteEmailAsync(registroRequest.Email);
            if (emailExiste)
                throw new InvalidOperationException("Já existe um usuário com este email.");

            var usernameExiste = await _usuarioRepository.ExisteUsernameAsync(registroRequest.Username);
            if (usernameExiste)
                throw new InvalidOperationException("Já existe um usuário com este username.");

            var novoUsuario = new Usuario
            {
                Nome = registroRequest.Nome,
                Username = registroRequest.Username,
                Email = registroRequest.Email,
                Senha = _senhaHashService.HashSenha(registroRequest.Senha),
                ImagemPerfilUrl = registroRequest.ImagemPerfilUrl,
                DataCadastro = DateTime.UtcNow,
                IsAtivo = true
            };

            var usuarioCriado = await _usuarioRepository.CriarAsync(novoUsuario);

            var usuarioDto = _mapper.Map<UsuarioDto>(usuarioCriado);

            return new LoginResponseDto
            {
                Usuario = usuarioDto,
                Token = "temp-token", // Substituir por JWT real depois
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };
        }
    }
}