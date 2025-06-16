using ArtezaStudio.Api.Dtos.Visualizacao;
using ArtezaStudio.Api.Repositories.Interfaces;
using ArtezaStudio.Api.Services.Interfaces;
using AutoMapper;

namespace ArtezaStudio.Api.Services
{
    public class VisualizacaoService : IVisualizacaoService
    {
        private readonly IVisualizacaoRepository _visualizacaoRepository;
        private readonly IMapper _mapper;

        public VisualizacaoService(IVisualizacaoRepository visualizacaoRepository, IMapper mapper)
        {
            _visualizacaoRepository = visualizacaoRepository;
            _mapper = mapper;
        }

        public async Task<VisualizacaoDto> CriarAsync(VisualizacaoFiltroDto visualizacaoFiltroDto)
        {
            var entity = _mapper.Map<Entities.Visualizacao>(visualizacaoFiltroDto);
            entity.UsuarioId = visualizacaoFiltroDto.UsuarioId;
            entity.PublicacaoId = visualizacaoFiltroDto.PublicacaoId;
            entity.Usuario = null;
            entity.Publicacao = null;

            var novaVisualizacao = await _visualizacaoRepository.CriarAsync(entity);
            return _mapper.Map<VisualizacaoDto>(novaVisualizacao);
        }

        public async Task<IEnumerable<VisualizacaoDto>> ListarPorPublicacaoIdAsync(Guid publicacaoId)
        {
            var visualizacoes = await _visualizacaoRepository.ListarPorPublicacaoIdAsync(publicacaoId);
            return _mapper.Map<IEnumerable<VisualizacaoDto>>(visualizacoes);
        }
    }
}