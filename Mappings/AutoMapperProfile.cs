using ArtezaStudio.Api.Dtos.Comentario;
using ArtezaStudio.Api.Dtos.Curtida;
using ArtezaStudio.Api.Dtos.Publicacao;
using ArtezaStudio.Api.Dtos.Usuario;
using ArtezaStudio.Api.Entities;
using AutoMapper;

namespace ArtezaStudio.Api.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Publicacao, PublicacaoDto>();
            CreateMap<PublicacaoFiltroDto, Publicacao>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());


            CreateMap<Comentario, ComentarioDto>();
            CreateMap<ComentarioFiltroDto, Comentario>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            CreateMap<Curtida, CurtidaDto>();
            CreateMap<CurtidaFiltroDto, Curtida>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<UsuarioFiltroDto, Usuario>();
            CreateMap<Usuario, UsuarioFiltroDto>();
        }
    }
}
