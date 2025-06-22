using ArtezaStudio.Api.Dtos.Usuario;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Repositories.Interfaces;
using ArtezaStudio.Api.Services.Interfaces;
using AutoMapper;

namespace ArtezaStudio.Api.Repositories
{
    public class UsuarioSeguidorService : IUsuarioSeguidorService
    {
        private readonly IUsuarioSeguidorRepository _usuarioSeguidorRepository;
        private readonly IMapper _mapper;

        public UsuarioSeguidorService(IUsuarioSeguidorRepository usuarioSeguidorRepository, IMapper mapper)
        {
            _usuarioSeguidorRepository = usuarioSeguidorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguidoresAsync(Guid usuarioId)
        {
            var seguidores = await _usuarioSeguidorRepository.ListarSeguidoresAsync(usuarioId);
            return _mapper.Map<IEnumerable<UsuarioSeguidorDto>>(seguidores);
        }

        public async Task<IEnumerable<UsuarioSeguidorDto>> ListarSeguindoAsync(Guid usuarioId)
        {
            var seguindo = await _usuarioSeguidorRepository.ListarSeguindoAsync(usuarioId);
            return _mapper.Map<IEnumerable<UsuarioSeguidorDto>>(seguindo);
        }

        public async Task<UsuarioSeguidorDto> SeguirUsuarioAsync(SeguirUsuarioDto seguirUsuarioDto)
        {
            var entity = _mapper.Map<UsuarioSeguidor>(seguirUsuarioDto);
            var result = await _usuarioSeguidorRepository.SeguirUsuarioAsync(entity);
            return _mapper.Map<UsuarioSeguidorDto>(result);
        }

        public async Task<bool> UnfollowAsync(SeguirUsuarioDto seguirUsuarioDto)
        {
            return await _usuarioSeguidorRepository.UnfollowAsync(seguirUsuarioDto);
        }
    }
}
