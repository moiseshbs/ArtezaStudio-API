using ArtezaStudio.Api.Dtos.Tag;
using ArtezaStudio.Api.Responses;
using ArtezaStudio.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtezaStudio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("listarTags/")]
        public async Task<IActionResult> Listar()
        {
            var tags = await _tagService.ListarAsync();
            return Ok(tags);
        }

        [HttpGet("listarPorNome/")]
        public async Task<IActionResult> ListarPorNome([FromQuery] string tagNome)
        {
            var tags = await _tagService.ListarPorNomeAsync(tagNome);
            return Ok(tags);
        }

        [HttpPost("criarTag/")]
        public async Task<IActionResult> Criar([FromBody] TagFiltroDto tagFiltroDto)
        {
            if (tagFiltroDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var tag = await _tagService.CriarAsync(tagFiltroDto);
            return Ok(ApiResponse<TagDto>.Ok(tag, "Tag criada com sucesso."));
        }

        [HttpDelete("excluirTag/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var resultado = await _tagService.ExcluirAsync(id);
            if (!resultado)
            {
                return NotFound("Tag não encontrada.");
            }
            return Ok(ApiResponse<bool>.Ok(true, "Tag excluída com sucesso."));
        }
    }
}
