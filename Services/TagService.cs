using ArtezaStudio.Api.Dtos.Tag;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Repositories.Interfaces;
using ArtezaStudio.Api.Services.Interfaces;
using AutoMapper;

namespace ArtezaStudio.Api.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> ListarAsync()
        {
            var tags = await _tagRepository.ListarAsync();
            return _mapper.Map<IEnumerable<TagDto>>(tags);
        }

        public async Task<IEnumerable<TagDto>> ListarPorNomeAsync(string tagNome)
        {
            var tags = await _tagRepository.ListarPorNomeAsync(tagNome);
            return _mapper.Map<IEnumerable<TagDto>>(tags);
        }

        public async Task<TagDto> CriarAsync(TagFiltroDto tagFiltroDto)
        {
            var entity = _mapper.Map<Tag>(tagFiltroDto);
            var novaTag = await _tagRepository.CriarAsync(entity);
            return _mapper.Map<TagDto>(novaTag);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            return await _tagRepository.ExcluirAsync(id);
        }
    }
}
