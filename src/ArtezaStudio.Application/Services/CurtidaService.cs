using ArtezaStudio.Application.Dtos.Curtida;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Interfaces;
using ArtezaStudio.Application.Services.Interfaces;
using AutoMapper;

namespace ArtezaStudio.Application.Services
{
    public class CurtidaService : ICurtidaService
    {
        private readonly ICurtidaRepository _curtidaRepository;
        private readonly IMapper _mapper;

        public CurtidaService(ICurtidaRepository curtidaRepository, IMapper mapper)
        {
            _curtidaRepository = curtidaRepository;
            _mapper = mapper;
        }

        public async Task<CurtidaDto> CriarAsync(CurtidaFiltroDto curtidaFiltroDto)
        {
            var entity = _mapper.Map<Curtida>(curtidaFiltroDto);
            entity.UsuarioId = curtidaFiltroDto.UsuarioId;
            entity.PublicacaoId = curtidaFiltroDto.PublicacaoId;
            entity.Usuario = null;
            entity.Publicacao = null;

            var novaCurtida = await _curtidaRepository.CriarAsync(entity);
            return _mapper.Map<CurtidaDto>(novaCurtida);
        }

        public async Task<bool> ExcluirAsync(long id)
        {
            return await _curtidaRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<CurtidaDto>> ListarPorPublicacaoIdAsync(long publicacaoId)
        {
            var curtidas = await _curtidaRepository.ListarPorPublicacaoIdAsync(publicacaoId);
            return _mapper.Map<IEnumerable<CurtidaDto>>(curtidas);
        }
    }
}
