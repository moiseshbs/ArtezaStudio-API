using ArtezaStudio.Application.Dtos.Publicacao;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Domain.Interfaces;
using ArtezaStudio.Application.Services.Interfaces;
using AutoMapper;
using ArtezaStudio.Application.Exceptions;
using ArtezaStudio.Domain.Enums;
using System.Net;
using ArtezaStudio.Application.Dtos.Common;

namespace ArtezaStudio.Application.Services
{
    public class PublicacaoService(IPublicacaoRepository publicacaoRepository, IMapper mapper) : IPublicacaoService
    {
        private readonly IPublicacaoRepository _publicacaoRepository = publicacaoRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PagedResult<PublicacaoDto>> ListarAsync(int page = 1, int pageSize = 10)
        {
            var (items, totalCount) = await _publicacaoRepository.ListarAsync(page, pageSize);
            return new PagedResult<PublicacaoDto>
            {
                Items = _mapper.Map<IEnumerable<PublicacaoDto>>(items),
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<PagedResult<PublicacaoDto>> ListarPorUsuarioIdAsync(long usuarioId, int page = 1, int pageSize = 10)
        {
            var (items, totalCount) = await _publicacaoRepository.ListarPorUsuarioIdAsync(usuarioId, page, pageSize);
            return new PagedResult<PublicacaoDto>
            {
                Items = _mapper.Map<IEnumerable<PublicacaoDto>>(items),
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<PagedResult<PublicacaoDto>> ListarPorTagIdAsync(long tagId, int page = 1, int pageSize = 10)
        {
            var (items, totalCount) = await _publicacaoRepository.ListarPorTagIdAsync(tagId, page, pageSize);
            return new PagedResult<PublicacaoDto>
            {
                Items = _mapper.Map<IEnumerable<PublicacaoDto>>(items),
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<PagedResult<PublicacaoDto>> ListarPorTermoAsync(string termo, int page = 1, int pageSize = 10)
        {
            var (items, totalCount) = await _publicacaoRepository.ListarPorTermoAsync(termo, page, pageSize);
            return new PagedResult<PublicacaoDto>
            {
                Items = _mapper.Map<IEnumerable<PublicacaoDto>>(items),
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<PublicacaoDto> CriarAsync(PublicacaoFiltroDto publicacaoFiltroDto)
        {
            var entity = _mapper.Map<Publicacao>(publicacaoFiltroDto);

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

        public async Task<PublicacaoDto> ObterPorIdAsync(long id)
        {
            var publicacao = await _publicacaoRepository.ObterPorIdAsync(id);
            if (publicacao == null)
                throw new ArtezaException("Publicação não encontrada.", ErrorCode.Publicacao.PublicacaoNaoEncontrada, HttpStatusCode.NotFound);

            return _mapper.Map<PublicacaoDto>(publicacao);
        }

        public async Task<bool> ExcluirAsync(long id)
        {
            var excluido = await _publicacaoRepository.ExcluirAsync(id);
            if (!excluido)
                throw new ArtezaException("Publicação não encontrada.", ErrorCode.Publicacao.PublicacaoNaoEncontrada, HttpStatusCode.NotFound);

            return true;
        }

        public async Task<PublicacaoDto> AtualizarAsync(PublicacaoFiltroDto publicacaoFiltroDto)
        {
            var entity = _mapper.Map<Publicacao>(publicacaoFiltroDto);
            var publicacaoAtualizada = await _publicacaoRepository.AtualizarAsync(entity);
            return _mapper.Map<PublicacaoDto>(publicacaoAtualizada);
        }
    }
}
