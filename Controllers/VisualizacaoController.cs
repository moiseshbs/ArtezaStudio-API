using ArtezaStudio.Api.Dtos.Visualizacao;
using ArtezaStudio.Api.Responses;
using ArtezaStudio.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtezaStudio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisualizacaoController : ControllerBase
    {
        private readonly IVisualizacaoService _visualizacaoService;

        public VisualizacaoController(IVisualizacaoService visualizacaoService)
        {
            _visualizacaoService = visualizacaoService;
        }

        [HttpGet("listarVisualizacoes/{idPublicacao}")]
        public async Task<IActionResult> ListarPorPublicacaoIdAsync(Guid idPublicacao)
        {
            var visualizacoes = await _visualizacaoService.ListarPorPublicacaoIdAsync(idPublicacao);
            return Ok(visualizacoes);
        }

        [HttpPost("criarVisualizacao/")]
        public async Task<IActionResult> CriarAsync([FromBody] VisualizacaoFiltroDto visualizacaoFiltroDto)
        {
            if (visualizacaoFiltroDto == null)
                return BadRequest("Dados da visualização inválidos.");

            var novaVisualizacao = await _visualizacaoService.CriarAsync(visualizacaoFiltroDto);
            return Ok(ApiResponse<VisualizacaoDto>.Ok(novaVisualizacao, "Visualização criada com sucesso"));
        }
    }
}
