using ArtezaStudio.Application.Dtos.Usuario;
using ArtezaStudio.Api.Responses;
using ArtezaStudio.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ArtezaStudio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("listarUsuarios/")]
        [Authorize]
        public async Task<IActionResult> Listar()
        {
            var usuarios = await _usuarioService.ListarAsync();
            return Ok(usuarios);
        }

        [HttpGet("buscarPorId/{id}")]
        public async Task<IActionResult> ObterPorId(long id)
        {
            var usuario = await _usuarioService.ObterPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuario);
        }

        [HttpGet("buscarPorEmail/")]
        public async Task<IActionResult> ObterPorEmail([FromQuery] string email)
        {
            var usuario = await _usuarioService.ObterPorEmailAsync(email);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuario);
        }

        [HttpGet("buscarPorUsername/")]
        public async Task<IActionResult> ObterPorUsername([FromQuery] string username)
        {
            var usuario = await _usuarioService.ObterPorUsernameAsync(username);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuario);
        }

        [HttpPut("atualizarUsuario/")]
        public async Task<IActionResult> Atualizar([FromBody] UsuarioFiltroDto usuarioFiltroDto)
        {
            if (usuarioFiltroDto == null || usuarioFiltroDto.Id == 0)
            {
                return BadRequest("Dados inválidos.");
            }
            var usuarioExistente = await _usuarioService.ObterPorIdAsync(usuarioFiltroDto.Id);
            if (usuarioExistente == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            if (usuarioFiltroDto.Email.Equals(usuarioExistente.Email) == false)
            {
                var existeEmail = await _usuarioService.ExisteEmailAsync(usuarioFiltroDto.Email);
                if (existeEmail)
                {
                    return BadRequest("Já existe um usuário com este email.");
                }
            }

            if (usuarioFiltroDto.Username.Equals(usuarioExistente.Username) == false)
            {
                var existeUsername = await _usuarioService.ExisteUsernameAsync(usuarioFiltroDto.Username);
                if (existeUsername)
                {
                    return BadRequest("Já existe um usuário com este username.");
                }
            }

            var atualizado = await _usuarioService.AtualizarAsync(usuarioFiltroDto);
            return Ok(ApiResponse<UsuarioDto>.Ok(atualizado, "Usuário atualizado com sucesso."));
        }

        [HttpDelete("excluirUsuario/{id}")]
        public async Task<IActionResult> Excluir(long id)
        {
            var usuarioExistente = await _usuarioService.ObterPorIdAsync(id);
            if (usuarioExistente == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            var excluido = await _usuarioService.ExcluirAsync(id);
            if (!excluido)
            {
                return BadRequest("Erro ao excluir o usuário.");
            }
            return Ok(ApiResponse<bool>.Ok(true, "Usuário excluído com sucesso."));
        }
    }
}
