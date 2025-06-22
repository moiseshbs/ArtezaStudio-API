using ArtezaStudio.Api.Dtos.Publicacao;
using ArtezaStudio.Api.Responses;
using ArtezaStudio.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtezaStudio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicacaoController : ControllerBase
    {
        private readonly IPublicacaoService _publicacaoService;

        public PublicacaoController(IPublicacaoService publicacaoService)
        {
            _publicacaoService = publicacaoService;
        }

        [HttpGet("listarPublicacoes/")]
        public async Task<IActionResult> Listar()
        {
            var publicacoes = await _publicacaoService.ListarAsync();
            return Ok(publicacoes);
        }

        [HttpGet("listarPublicacoesPorUsuario/{usuarioId}")]
        public async Task<IActionResult> ListarPorUsuario(Guid usuarioId)
        {
            var publicacoes = await _publicacaoService.ListarPorUsuarioIdAsync(usuarioId);
            return Ok(publicacoes);
        }

        [HttpGet("listarPublicacoesPorTag/{tagId}")]
        public async Task<IActionResult> ListarPorTag(Guid tagId)
        {
            var publicacoes = await _publicacaoService.ListarPorTagIdAsync(tagId);
            return Ok(publicacoes);
        }

        [HttpGet("listarPublicacoesPorTermo/{termo}")]
        public async Task<IActionResult> ListarPorTermo(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                return BadRequest("Termo de pesquisa inválido.");
            }
            var publicacoes = await _publicacaoService.ListarPorTermoAsync(termo);
            return Ok(publicacoes);
        }

        [HttpPost("criarPublicacao/")]
        public async Task<IActionResult> Criar([FromBody] PublicacaoFiltroDto publicacaoFiltroDto)
        {
            if (publicacaoFiltroDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var novaPublicacao = await _publicacaoService.CriarAsync(publicacaoFiltroDto);
            return Ok(ApiResponse<PublicacaoDto>.Ok(novaPublicacao, "Publicação criada com sucesso"));
        }

        [HttpGet("obterPublicacao/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var publicacao = await _publicacaoService.ObterPorIdAsync(id);
            if (publicacao == null)
            {
                return NotFound("Publicação não encontrada.");
            }
            return Ok(publicacao);
        }

        [HttpDelete("excluirPublicacao/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var resultado = await _publicacaoService.ExcluirAsync(id);
            if (!resultado)
            {
                return NotFound("Publicação não encontrada.");
            }
            return Ok(ApiResponse<bool>.Ok(true, "Publicação excluída com sucesso."));
        }

        [HttpPut("atualizarPublicacao/")]
        public async Task<IActionResult> Atualizar([FromBody] PublicacaoFiltroDto publicacaoFiltroDto)
        {
            if (publicacaoFiltroDto == null)
            {
                return BadRequest("Dados inválidos.");
            }
            var publicacaoAtualizada = await _publicacaoService.AtualizarAsync(publicacaoFiltroDto);
            return Ok(ApiResponse<PublicacaoDto>.Ok(publicacaoAtualizada, "Publicação atualizada com sucesso."));
        }
    }
}