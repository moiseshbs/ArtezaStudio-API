using ArtezaStudio.Api.Dtos.Comentario;
using ArtezaStudio.Api.Responses;
using ArtezaStudio.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtezaStudio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _comentarioService;

        public ComentarioController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpGet("listarComentarios/{idPublicacao}")]
        public async Task<IActionResult> ListarPorPublicacaoIdAsync(Guid idPublicacao)
        {
            var comentarios = await _comentarioService.ListarPorPublicacaoIdAsync(idPublicacao);
            if (comentarios == null || !comentarios.Any())
                return NotFound("Nenhum comentário encontrado para esta publicação.");

            return Ok(comentarios);
        }

        [HttpPost("criarComentario/")]
        public async Task<IActionResult> CriarAsync([FromBody] ComentarioFiltroDto comentarioFiltroDto)
        {
            if (comentarioFiltroDto == null)
                return BadRequest("Dados do comentário inválidos.");

            var novoComentario = await _comentarioService.CriarAsync(comentarioFiltroDto);
            return Ok(ApiResponse<ComentarioDto>.Ok(novoComentario, "Comentário criado com sucesso"));
        }

        [HttpPut("atualizarComentario/")]
        public async Task<IActionResult> AtualizarAsync([FromBody] ComentarioFiltroDto comentarioFiltroDto)
        {
            if (comentarioFiltroDto == null || comentarioFiltroDto.Id == Guid.Empty)
                return BadRequest("Dados do comentário inválidos.");

            var comentarioAtualizado = await _comentarioService.AtualizarAsync(comentarioFiltroDto);
            return Ok(ApiResponse<ComentarioDto>.Ok(comentarioAtualizado, "Comentário atualizado com sucesso."));
        }

        [HttpDelete("excluirComentario/{id}")]
        public async Task<IActionResult> ExcluirAsync(Guid id)
        {
            var excluido = await _comentarioService.ExcluirAsync(id);
            if (!excluido)
                return NotFound("Erro ao excluir comentário.");
            return Ok(ApiResponse<bool>.Ok(true, "Comentário excluído com sucesso."));
        }
    }
}