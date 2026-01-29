using ArtezaStudio.Application.Dtos.Comentario;
using ArtezaStudio.Application.Dtos.Curtida;
using ArtezaStudio.Application.Dtos.Publicacao;
using ArtezaStudio.Application.Dtos.Tag;
using ArtezaStudio.Application.Dtos.Usuario;
using ArtezaStudio.Application.Dtos.Visualizacao;
using ArtezaStudio.Domain.Entities;
using AutoMapper;

namespace ArtezaStudio.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Publicacao, PublicacaoDto>();
            CreateMap<PublicacaoFiltroDto, Publicacao>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());
            CreateMap<PublicacaoFiltroDto, Publicacao>()
                .ForMember(dest => dest.PublicacaoTags, opt => opt.Ignore());

            CreateMap<Comentario, ComentarioDto>();
            CreateMap<ComentarioFiltroDto, Comentario>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            CreateMap<Curtida, CurtidaDto>();
            CreateMap<CurtidaFiltroDto, Curtida>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            CreateMap<Visualizacao, VisualizacaoDto>();
            CreateMap<VisualizacaoFiltroDto, Visualizacao>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<UsuarioFiltroDto, Usuario>();
            CreateMap<Usuario, UsuarioFiltroDto>();

            CreateMap<Tag, TagDto>()
                .ForMember(dest => dest.PublicacaoTags, opt => opt.Ignore());
            CreateMap<TagFiltroDto, Tag>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PublicacaoTags, opt => opt.Ignore());

            CreateMap<PublicacaoTag, PublicacaoTagDto>()
                .ForMember(dest => dest.Publicacao, opt => opt.Ignore());

            CreateMap<UsuarioSeguidor, UsuarioSeguidorDto>();
            CreateMap<SeguirUsuarioDto, UsuarioSeguidor>()
                .ForMember(dest => dest.Seguidor, opt => opt.Ignore())
                .ForMember(dest => dest.Seguido, opt => opt.Ignore());
        }
    }
}
