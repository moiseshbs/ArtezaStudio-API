using ArtezaStudio.Application.Dtos.Usuario;
using ArtezaStudio.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtezaStudio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioSeguidorController : ControllerBase
    {
        private readonly IUsuarioSeguidorService _usuarioSeguidorService;

        public UsuarioSeguidorController(IUsuarioSeguidorService usuarioSeguidorService)
        {
            _usuarioSeguidorService = usuarioSeguidorService;
        }

        [HttpGet("listarSeguidores/{usuarioId}")]
        public async Task<IActionResult> ListarSeguidores(long usuarioId)
        {
            var seguidores = await _usuarioSeguidorService.ListarSeguidoresAsync(usuarioId);
            return Ok(seguidores);
        }

        [HttpGet("listarSeguindo/{usuarioId}")]
        public async Task<IActionResult> ListarSeguindo(long usuarioId)
        {
            var seguindo = await _usuarioSeguidorService.ListarSeguindoAsync(usuarioId);
            return Ok(seguindo);
        }

        [HttpPost("seguirUsuario/")]
        [Authorize]
        public async Task<IActionResult> SeguirUsuario([FromBody] SeguirUsuarioDto seguirUsuarioDto)
        {
            if (seguirUsuarioDto == null)
            {
                return BadRequest("Dados inválidos.");
            }
            var resultado = await _usuarioSeguidorService.SeguirUsuarioAsync(seguirUsuarioDto);
            return Ok(resultado);
        }

        [HttpDelete("unfollow/")]
        [Authorize]
        public async Task<IActionResult> Unfollow([FromBody] SeguirUsuarioDto seguirUsuarioDto)
        {
            if (seguirUsuarioDto == null)
            {
                return BadRequest("Dados inválidos.");
            }
            var resultado = await _usuarioSeguidorService.UnfollowAsync(seguirUsuarioDto);
            return Ok(resultado);
        }
    }
}
