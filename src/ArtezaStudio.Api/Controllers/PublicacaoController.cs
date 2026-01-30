using ArtezaStudio.Application.Dtos.Publicacao;
using ArtezaStudio.Api.Responses;
using ArtezaStudio.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ArtezaStudio.Application.Dtos.Common;

namespace ArtezaStudio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicacaoController(IPublicacaoService publicacaoService) : ControllerBase
    {
        private readonly IPublicacaoService _publicacaoService = publicacaoService;

        [HttpGet("listarPublicacoes/")]
        public async Task<IActionResult> Listar([FromQuery] PaginationParams paginationParams)
        {
            var publicacoes = await _publicacaoService.ListarAsync(paginationParams.Page, paginationParams.PageSize);
            return Ok(publicacoes);
        }

        [HttpGet("listarPublicacoesPorUsuario/{usuarioId}")]
        public async Task<IActionResult> ListarPorUsuario(long usuarioId, [FromQuery] PaginationParams paginationParams)
        {
            var publicacoes = await _publicacaoService.ListarPorUsuarioIdAsync(usuarioId, paginationParams.Page, paginationParams.PageSize);
            return Ok(publicacoes);
        }

        [HttpGet("listarPublicacoesPorTag/{tagId}")]
        public async Task<IActionResult> ListarPorTag(long tagId, [FromQuery] PaginationParams paginationParams)
        {
            var publicacoes = await _publicacaoService.ListarPorTagIdAsync(tagId, paginationParams.Page, paginationParams.PageSize);
            return Ok(publicacoes);
        }

        [HttpGet("listarPublicacoesPorTermo/{termo}")]
        public async Task<IActionResult> ListarPorTermo(string termo, [FromQuery] PaginationParams paginationParams)
        {
            var publicacoes = await _publicacaoService.ListarPorTermoAsync(termo, paginationParams.Page, paginationParams.PageSize);
            return Ok(publicacoes);
        }

        [HttpPost("criarPublicacao/")]
        [Authorize]
        public async Task<IActionResult> Criar([FromBody] PublicacaoFiltroDto publicacaoFiltroDto)
        {
            var novaPublicacao = await _publicacaoService.CriarAsync(publicacaoFiltroDto);
            return Ok(ApiResponse<PublicacaoDto>.Ok(novaPublicacao, "Publicação criada com sucesso"));
        }

        [HttpGet("obterPublicacao/{id}")]
        public async Task<IActionResult> ObterPorId(long id)
        {
            var publicacao = await _publicacaoService.ObterPorIdAsync(id);
            return Ok(publicacao);
        }

        [HttpDelete("excluirPublicacao/{id}")]
        [Authorize]
        public async Task<IActionResult> Excluir(long id)
        {
            await _publicacaoService.ExcluirAsync(id);
            return Ok(ApiResponse<bool>.Ok(true, "Publicação excluída com sucesso."));
        }

        [HttpPut("atualizarPublicacao/")]
        [Authorize]
        public async Task<IActionResult> Atualizar([FromBody] PublicacaoFiltroDto publicacaoFiltroDto)
        {
            var publicacaoAtualizada = await _publicacaoService.AtualizarAsync(publicacaoFiltroDto);
            return Ok(ApiResponse<PublicacaoDto>.Ok(publicacaoAtualizada, "Publicação atualizada com sucesso."));
        }
    }
}