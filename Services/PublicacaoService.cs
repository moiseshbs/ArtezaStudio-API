using ArtezaStudio.Api.Dtos.Publicacao;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Repositories.Interfaces;
using ArtezaStudio.Api.Services.Interfaces;
using AutoMapper;

namespace ArtezaStudio.Api.Services
{
    public class PublicacaoService : IPublicacaoService
    {
        private readonly IPublicacaoRepository _publicacaoRepository;
        private readonly IMapper _mapper;
        public PublicacaoService(IPublicacaoRepository publicacaoRepository, IMapper mapper)
        {
            _publicacaoRepository = publicacaoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PublicacaoDto>> ListarAsync()
        {
            var publicacoes = await _publicacaoRepository.ListarAsync();
            return _mapper.Map<IEnumerable<PublicacaoDto>>(publicacoes);
        }

        public async Task<IEnumerable<PublicacaoDto>> ListarPorUsuarioIdAsync(Guid usuarioId)
        {
            var publicacoes = await _publicacaoRepository.ListarPorUsuarioIdAsync(usuarioId);
            return _mapper.Map<IEnumerable<PublicacaoDto>>(publicacoes);
        }

        public async Task<IEnumerable<PublicacaoDto>> ListarPorTagIdAsync(Guid tagId)
        {
            var publicacoes = await _publicacaoRepository.ListarPorTagIdAsync(tagId);
            return _mapper.Map<IEnumerable<PublicacaoDto>>(publicacoes);
        }

        public async Task<IEnumerable<PublicacaoDto>> ListarPorTermoAsync(string termo)
        {
            var publicacoes = await _publicacaoRepository.ListarPorTermoAsync(termo);
            return _mapper.Map<IEnumerable<PublicacaoDto>>(publicacoes);
        }

        public async Task<PublicacaoDto> CriarAsync(PublicacaoFiltroDto publicacaoFiltroDto)
        {
            var entity = _mapper.Map<Publicacao>(publicacaoFiltroDto);
            entity.UsuarioId = publicacaoFiltroDto.UsuarioId;
            entity.Usuario = null;

            var novaPublicacao = await _publicacaoRepository.CriarAsync(entity);

            if (publicacaoFiltroDto.TagIds != null && publicacaoFiltroDto.TagIds.Any())
            {
                foreach (var tagId in publicacaoFiltroDto.TagIds)
                {
                    var publicacaoTag = new PublicacaoTag
                    {
                        PublicacaoId = novaPublicacao.Id,
                        TagId = tagId
                    };

                    await _publicacaoRepository.AdicionarPublicacaoTagAsync(publicacaoTag);
                }
            }

            return _mapper.Map<PublicacaoDto>(novaPublicacao);
        }

        public async Task<PublicacaoDto> ObterPorIdAsync(Guid id)
        {
            var publicacao = await _publicacaoRepository.ObterPorIdAsync(id);
            return _mapper.Map<PublicacaoDto>(publicacao);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            return await _publicacaoRepository.ExcluirAsync(id);
        }

        public async Task<PublicacaoDto> AtualizarAsync(PublicacaoFiltroDto publicacaoFiltroDto)
        {
            var entity = _mapper.Map<Publicacao>(publicacaoFiltroDto);
            var publicacaoAtualizada = await _publicacaoRepository.AtualizarAsync(entity);
            return _mapper.Map<PublicacaoDto>(publicacaoAtualizada);
        }
    }
}
