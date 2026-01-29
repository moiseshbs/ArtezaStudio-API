using ArtezaStudio.Application.Dtos.Comentario;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Interfaces;
using ArtezaStudio.Application.Services.Interfaces;
using AutoMapper;

namespace ArtezaStudio.Application.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;
        private readonly IMapper _mapper;

        public ComentarioService(IComentarioRepository comentarioRepository, IMapper mapper)
        {
            _comentarioRepository = comentarioRepository;
            _mapper = mapper;
        }

        public async Task<ComentarioDto> AtualizarAsync(ComentarioFiltroDto comentarioFiltroDto)
        {
            var entity = _mapper.Map<Comentario>(comentarioFiltroDto);
            var comentarioAtualizado = await _comentarioRepository.AtualizarAsync(entity);
            return _mapper.Map<ComentarioDto>(comentarioAtualizado);
        }

        public async Task<ComentarioDto> CriarAsync(ComentarioFiltroDto comentarioFiltroDto)
        {
            var entity = _mapper.Map<Comentario>(comentarioFiltroDto);
            entity.UsuarioId = comentarioFiltroDto.UsuarioId;
            entity.PublicacaoId = comentarioFiltroDto.PublicacaoId;
            entity.Usuario = null;
            entity.Publicacao = null;

            var novoComentario = await _comentarioRepository.CriarAsync(entity);
            return _mapper.Map<ComentarioDto>(novoComentario);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            return await _comentarioRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<ComentarioDto>> ListarPorPublicacaoIdAsync(Guid publicacaoId)
        {
            var comentarios = await _comentarioRepository.ListarPorPublicacaoIdAsync(publicacaoId);
            return _mapper.Map<IEnumerable<ComentarioDto>>(comentarios);
        }
    }
}
