using System.Net;
using ArtezaStudio.Application.Dtos.Auth;
using ArtezaStudio.Application.Dtos.Usuario;
using ArtezaStudio.Application.Exceptions;
using ArtezaStudio.Application.Services.Interfaces;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Enums;
using ArtezaStudio.Domain.Interfaces;
using AutoMapper;

namespace ArtezaStudio.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaHashService _senhaHashService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;

        public AuthService(IUsuarioRepository usuarioRepository, ISenhaHashService senhaHashService, IJwtTokenService jwtTokenService, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _senhaHashService = senhaHashService;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(loginRequest.Email);

            if (usuario == null)
                throw new ArtezaException("Email ou senha inválidos.", ErrorCode.Autenticacao.CredenciaisInvalidas, HttpStatusCode.Unauthorized);

            var senhaValida = _senhaHashService.VerificarSenha(loginRequest.Senha, usuario.Senha);
            
            if (!senhaValida)
                throw new ArtezaException("Email ou senha inválidos.", ErrorCode.Autenticacao.CredenciaisInvalidas, HttpStatusCode.Unauthorized);

            var token = _jwtTokenService.GerarToken(usuario);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return new LoginResponseDto
            {
                Usuario = usuarioDto,
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60)
            };
        }

        public async Task<LoginResponseDto> RegistrarAsync(RegistroRequestDto registroRequest)
        {
            var emailExiste = await _usuarioRepository.ExisteEmailAsync(registroRequest.Email);
            if (emailExiste)
                throw new ArtezaException("Já existe um usuário com este email.", ErrorCode.Usuario.EmailJaExiste, HttpStatusCode.BadRequest);

            var usernameExiste = await _usuarioRepository.ExisteUsernameAsync(registroRequest.Username);
            if (usernameExiste)
                throw new ArtezaException("Já existe um usuário com este username.", ErrorCode.Usuario.UsernameJaExiste, HttpStatusCode.BadRequest);
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

            var token = _jwtTokenService.GerarToken(usuarioCriado);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuarioCriado);

            return new LoginResponseDto
            {
                Usuario = usuarioDto,
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60)
            };
        }
    }
}