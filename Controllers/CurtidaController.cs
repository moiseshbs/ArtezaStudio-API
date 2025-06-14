using ArtezaStudio.Api.Dtos.Curtida;
using ArtezaStudio.Api.Responses;
using ArtezaStudio.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtezaStudio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtidaService _curtidaService;

        public CurtidaController(ICurtidaService curtidaService)
        {
            _curtidaService = curtidaService;
        }

        [HttpGet("listarCurtidas/{idPublicacao}")]
        public async Task<IActionResult> ListarPorPublicacaoIdAsync(Guid idPublicacao)
        {
            var curtidas = await _curtidaService.ListarPorPublicacaoIdAsync(idPublicacao);
            return Ok(curtidas);
        }

        [HttpPost("criarCurtida/")]
        public async Task<IActionResult> CriarAsync([FromBody] CurtidaFiltroDto curtidaFiltroDto)
        {
            if (curtidaFiltroDto == null)
                return BadRequest("Dados da curtida inválidos.");
            
            var novaCurtida = await _curtidaService.CriarAsync(curtidaFiltroDto);
            return Ok(ApiResponse<CurtidaDto>.Ok(novaCurtida, "Curtida criado com sucesso"));
        }

        [HttpDelete("excluirCurtida/{id}")]
        public async Task<IActionResult> ExcluirAsync(Guid id)
        {
            var excluido = await _curtidaService.ExcluirAsync(id);
            if (!excluido)
                return NotFound("Erro ao excluir curtida.");
            return Ok(ApiResponse<bool>.Ok(true, "Curtida excluida com sucesso."));
        }
    }
}
