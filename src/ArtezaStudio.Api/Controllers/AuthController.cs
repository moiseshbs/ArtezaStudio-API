using ArtezaStudio.Api.Responses;
using ArtezaStudio.Application.Dtos.Auth;
using ArtezaStudio.Application.Dtos.Usuario;
using ArtezaStudio.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtezaStudio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        /// <summary>
        /// Realiza o login do usuário
        /// </summary>
        [HttpPost("login/")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Senha))
            {
                return BadRequest(ApiResponse<string>.Erro("Email e senha são obrigatórios."));
            }

            try
            {
                var resultado = await _authService.LoginAsync(loginRequest);
                return Ok(ApiResponse<LoginResponseDto>.Ok(resultado, "Login realizado com sucesso."));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ApiResponse<string>.Erro(ex.Message));
            }
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        [HttpPost("registrar/")]
        public async Task<IActionResult> Registrar([FromBody] RegistroRequestDto registroRequest)
        {
            if (registroRequest == null)
            {
                return BadRequest(ApiResponse<string>.Erro("Dados inválidos."));
            }

            try
            {
                var resultado = await _authService.RegistrarAsync(registroRequest);
                return Ok(ApiResponse<LoginResponseDto>.Ok(resultado, "Usuário registrado com sucesso."));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<string>.Erro(ex.Message));
            }
        }
    }
}