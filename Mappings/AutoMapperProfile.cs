using ArtezaStudio.Api.Dtos.Comentario;
using ArtezaStudio.Api.Dtos.Curtida;
using ArtezaStudio.Api.Dtos.Publicacao;
using ArtezaStudio.Api.Dtos.Tag;
using ArtezaStudio.Api.Dtos.Usuario;
using ArtezaStudio.Api.Dtos.Visualizacao;
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
            CreateMap<TagFiltroDto, Tag>();

            CreateMap<PublicacaoTag, PublicacaoTagDto>()
                .ForMember(dest => dest.Publicacao, opt => opt.Ignore());
        }
    }
}
