using ArtezaStudio.Api.Dtos.Publicacao;
using ArtezaStudio.Api.Entities;
using ArtezaStudio.Api.Mappings;
using ArtezaStudio.Api.Repositories.Interfaces;
using ArtezaStudio.Api.Services;
using AutoMapper;
using Moq;
using Xunit;

namespace ArtezaStudio.Api.ArtezaStudio.Tests.Services
{
    public class PublicacaoServiceTests
    {
        private readonly IMapper _mapper;

        public PublicacaoServiceTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task CriarAsync_RetornaDtoValido()
        {
            // Arrange
            var repo = new Mock<IPublicacaoRepository>();
            var service = new PublicacaoService(repo.Object, _mapper);
            var publicacaoFiltroDto = new PublicacaoFiltroDto
            {
                Titulo = "Teste titulo",
                Descricao = "Teste descrição",
                ImagemUrl = "url"
            };

            repo.Setup(r => r.CriarAsync(It.IsAny<Publicacao>()))
                .ReturnsAsync(new Publicacao
                {
                    Id = Guid.NewGuid(),
                    Titulo = publicacaoFiltroDto.Titulo,
                    Descricao = publicacaoFiltroDto.Descricao,
                    ImagemUrl = publicacaoFiltroDto.ImagemUrl
                });

            // Act
            var result = await service.CriarAsync(publicacaoFiltroDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(publicacaoFiltroDto.Titulo, result.Titulo);
        }
    }
}
