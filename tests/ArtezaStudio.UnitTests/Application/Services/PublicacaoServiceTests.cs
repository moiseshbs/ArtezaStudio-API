using ArtezaStudio.Application.Dtos.Publicacao;
using ArtezaStudio.Application.Exceptions;
using ArtezaStudio.Domain.Entities;
using ArtezaStudio.Application.Mappings;
using ArtezaStudio.Domain.Interfaces;
using ArtezaStudio.Application.Services;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace ArtezaStudio.UnitTests.Application.Services
{
    public class PublicacaoServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPublicacaoRepository> _repositoryMock;
        private readonly PublicacaoService _service;

        public PublicacaoServiceTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();
            _repositoryMock = new Mock<IPublicacaoRepository>();
            _service = new PublicacaoService(_repositoryMock.Object, _mapper);
        }

        #region ListarAsync Tests

        [Fact]
        public async Task ListarAsync_DeveRetornarResultadoPaginado()
        {
            // Arrange
            var publicacoes = new List<Publicacao>
            {
                new() { Id = 1, Titulo = "Publicação 1", Descricao = "Desc 1", ImagemUrl = "url1" },
                new() { Id = 2, Titulo = "Publicação 2", Descricao = "Desc 2", ImagemUrl = "url2" }
            };

            _repositoryMock.Setup(r => r.ListarAsync(1, 10))
                .ReturnsAsync((publicacoes.AsEnumerable(), 2));

            // Act
            var result = await _service.ListarAsync(1, 10);

            // Assert
            result.Should().NotBeNull();
            result.Items.Should().HaveCount(2);
            result.TotalItems.Should().Be(2);
            result.Page.Should().Be(1);
            result.PageSize.Should().Be(10);
        }

        [Fact]
        public async Task ListarAsync_QuandoVazio_DeveRetornarListaVazia()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ListarAsync(1, 10))
                .ReturnsAsync((Enumerable.Empty<Publicacao>(), 0));

            // Act
            var result = await _service.ListarAsync(1, 10);

            // Assert
            result.Items.Should().BeEmpty();
            result.TotalItems.Should().Be(0);
        }

        #endregion

        #region ListarPorUsuarioIdAsync Tests

        [Fact]
        public async Task ListarPorUsuarioIdAsync_DeveRetornarPublicacoesDoUsuario()
        {
            // Arrange
            var usuarioId = 1L;
            var publicacoes = new List<Publicacao>
            {
                new() { Id = 1, Titulo = "Pub 1", UsuarioId = usuarioId, ImagemUrl = "url1" },
                new() { Id = 2, Titulo = "Pub 2", UsuarioId = usuarioId, ImagemUrl = "url2" }
            };

            _repositoryMock.Setup(r => r.ListarPorUsuarioIdAsync(usuarioId, 1, 10))
                .ReturnsAsync((publicacoes.AsEnumerable(), 2));

            // Act
            var result = await _service.ListarPorUsuarioIdAsync(usuarioId, 1, 10);

            // Assert
            result.Items.Should().HaveCount(2);
            result.Items.Should().AllSatisfy(p => p.UsuarioId.Should().Be(usuarioId));
        }

        [Fact]
        public async Task ListarPorUsuarioIdAsync_UsuarioSemPublicacoes_DeveRetornarVazio()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ListarPorUsuarioIdAsync(999, 1, 10))
                .ReturnsAsync((Enumerable.Empty<Publicacao>(), 0));

            // Act
            var result = await _service.ListarPorUsuarioIdAsync(999, 1, 10);

            // Assert
            result.Items.Should().BeEmpty();
        }

        #endregion

        #region ListarPorTagIdAsync Tests

        [Fact]
        public async Task ListarPorTagIdAsync_DeveRetornarPublicacoesComTag()
        {
            // Arrange
            var tagId = 1L;
            var publicacoes = new List<Publicacao>
            {
                new() 
                { 
                    Id = 1, 
                    Titulo = "Pub com Tag", 
                    ImagemUrl = "url1",
                    PublicacaoTags = new List<PublicacaoTag> 
                    { 
                        new() { TagId = tagId, PublicacaoId = 1 } 
                    } 
                }
            };

            _repositoryMock.Setup(r => r.ListarPorTagIdAsync(tagId, 1, 10))
                .ReturnsAsync((publicacoes.AsEnumerable(), 1));

            // Act
            var result = await _service.ListarPorTagIdAsync(tagId, 1, 10);

            // Assert
            result.Items.Should().HaveCount(1);
            result.TotalItems.Should().Be(1);
        }

        #endregion

        #region ListarPorTermoAsync Tests

        [Fact]
        public async Task ListarPorTermoAsync_DeveRetornarPublicacoesComTermo()
        {
            // Arrange
            var termo = "arte";
            var publicacoes = new List<Publicacao>
            {
                new() { Id = 1, Titulo = "Arte Digital", Descricao = "Desc", ImagemUrl = "url1" },
                new() { Id = 2, Titulo = "Pintura", Descricao = "Arte em tela", ImagemUrl = "url2" }
            };

            _repositoryMock.Setup(r => r.ListarPorTermoAsync(termo, 1, 10))
                .ReturnsAsync((publicacoes.AsEnumerable(), 2));

            // Act
            var result = await _service.ListarPorTermoAsync(termo, 1, 10);

            // Assert
            result.Items.Should().HaveCount(2);
        }

        [Fact]
        public async Task ListarPorTermoAsync_TermoNaoEncontrado_DeveRetornarVazio()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ListarPorTermoAsync("xyz123", 1, 10))
                .ReturnsAsync((Enumerable.Empty<Publicacao>(), 0));

            // Act
            var result = await _service.ListarPorTermoAsync("xyz123", 1, 10);

            // Assert
            result.Items.Should().BeEmpty();
        }

        #endregion

        #region CriarAsync Tests

        [Fact]
        public async Task CriarAsync_ComDadosValidos_DeveRetornarPublicacaoCriada()
        {
            // Arrange
            var dto = new PublicacaoFiltroDto
            {
                Titulo = "Nova Publicação",
                Descricao = "Descrição da publicação",
                ImagemUrl = "https://exemplo.com/imagem.jpg",
                UsuarioId = 1
            };

            var publicacaoCriada = new Publicacao
            {
                Id = 1,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao ?? string.Empty,
                ImagemUrl = dto.ImagemUrl,
                UsuarioId = dto.UsuarioId,
                DataPublicacao = DateTime.UtcNow
            };

            _repositoryMock.Setup(r => r.CriarAsync(It.IsAny<Publicacao>()))
                .ReturnsAsync(publicacaoCriada);

            // Act
            var result = await _service.CriarAsync(dto);

            // Assert
            result.Should().NotBeNull();
            result.Titulo.Should().Be(dto.Titulo);
            result.Descricao.Should().Be(dto.Descricao);
            result.ImagemUrl.Should().Be(dto.ImagemUrl);
            result.UsuarioId.Should().Be(dto.UsuarioId);
        }

        [Fact]
        public async Task CriarAsync_ComTags_DeveAdicionarTags()
        {
            // Arrange
            var dto = new PublicacaoFiltroDto
            {
                Titulo = "Publicação com Tags",
                Descricao = "Descrição",
                ImagemUrl = "https://exemplo.com/imagem.jpg",
                UsuarioId = 1,
                TagIds = new List<long> { 1, 2, 3 }
            };

            var publicacaoCriada = new Publicacao
            {
                Id = 1,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao ?? string.Empty,
                ImagemUrl = dto.ImagemUrl,
                UsuarioId = dto.UsuarioId
            };

            _repositoryMock.Setup(r => r.CriarAsync(It.IsAny<Publicacao>()))
                .ReturnsAsync(publicacaoCriada);

            _repositoryMock.Setup(r => r.AdicionarPublicacaoTagAsync(It.IsAny<PublicacaoTag>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.CriarAsync(dto);

            // Assert
            result.Should().NotBeNull();
            _repositoryMock.Verify(
                r => r.AdicionarPublicacaoTagAsync(It.IsAny<PublicacaoTag>()), 
                Times.Exactly(3));
        }

        [Fact]
        public async Task CriarAsync_SemTags_NaoDeveAdicionarTags()
        {
            // Arrange
            var dto = new PublicacaoFiltroDto
            {
                Titulo = "Publicação sem Tags",
                Descricao = "Descrição",
                ImagemUrl = "https://exemplo.com/imagem.jpg",
                UsuarioId = 1,
                TagIds = null
            };

            var publicacaoCriada = new Publicacao
            {
                Id = 1,
                Titulo = dto.Titulo,
                ImagemUrl = dto.ImagemUrl
            };

            _repositoryMock.Setup(r => r.CriarAsync(It.IsAny<Publicacao>()))
                .ReturnsAsync(publicacaoCriada);

            // Act
            await _service.CriarAsync(dto);

            // Assert
            _repositoryMock.Verify(
                r => r.AdicionarPublicacaoTagAsync(It.IsAny<PublicacaoTag>()), 
                Times.Never);
        }

        #endregion

        #region ObterPorIdAsync Tests

        [Fact]
        public async Task ObterPorIdAsync_QuandoExiste_DeveRetornarPublicacao()
        {
            // Arrange
            var publicacao = new Publicacao
            {
                Id = 1,
                Titulo = "Publicação Existente",
                Descricao = "Descrição",
                ImagemUrl = "https://exemplo.com/imagem.jpg",
                UsuarioId = 1
            };

            _repositoryMock.Setup(r => r.ObterPorIdAsync(1))
                .ReturnsAsync(publicacao);

            // Act
            var result = await _service.ObterPorIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Titulo.Should().Be("Publicação Existente");
        }

        [Fact]
        public async Task ObterPorIdAsync_QuandoNaoExiste_DeveLancarExcecao()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ObterPorIdAsync(999))
                .ReturnsAsync((Publicacao?)null);

            // Act
            var act = async () => await _service.ObterPorIdAsync(999);

            // Assert
            await act.Should().ThrowAsync<ArtezaException>()
                .WithMessage("Publicação não encontrada.");
        }

        #endregion

        #region ExcluirAsync Tests

        [Fact]
        public async Task ExcluirAsync_QuandoExiste_DeveRetornarTrue()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ExcluirAsync(1))
                .ReturnsAsync(true);

            // Act
            var result = await _service.ExcluirAsync(1);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task ExcluirAsync_QuandoNaoExiste_DeveLancarExcecao()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ExcluirAsync(999))
                .ReturnsAsync(false);

            // Act
            var act = async () => await _service.ExcluirAsync(999);

            // Assert
            await act.Should().ThrowAsync<ArtezaException>()
                .WithMessage("Publicação não encontrada.");
        }

        #endregion

        #region AtualizarAsync Tests

        [Fact]
        public async Task AtualizarAsync_ComDadosValidos_DeveRetornarPublicacaoAtualizada()
        {
            // Arrange
            var dto = new PublicacaoFiltroDto
            {
                Id = 1,
                Titulo = "Título Atualizado",
                Descricao = "Descrição Atualizada",
                ImagemUrl = "https://exemplo.com/nova-imagem.jpg",
                UsuarioId = 1
            };

            var publicacaoAtualizada = new Publicacao
            {
                Id = 1,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao ?? string.Empty,
                ImagemUrl = dto.ImagemUrl,
                UsuarioId = dto.UsuarioId
            };

            _repositoryMock.Setup(r => r.AtualizarAsync(It.IsAny<Publicacao>()))
                .ReturnsAsync(publicacaoAtualizada);

            // Act
            var result = await _service.AtualizarAsync(dto);

            // Assert
            result.Should().NotBeNull();
            result.Titulo.Should().Be("Título Atualizado");
            result.Descricao.Should().Be("Descrição Atualizada");
        }

        [Fact]
        public async Task AtualizarAsync_QuandoNaoExiste_DeveLancarExcecao()
        {
            // Arrange
            var dto = new PublicacaoFiltroDto
            {
                Id = 999,
                Titulo = "Título",
                ImagemUrl = "https://exemplo.com/imagem.jpg",
                UsuarioId = 1
            };

            _repositoryMock.Setup(r => r.AtualizarAsync(It.IsAny<Publicacao>()))
                .ThrowsAsync(new KeyNotFoundException("Publicação não encontrada."));

            // Act
            var act = async () => await _service.AtualizarAsync(dto);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }

        #endregion

        #region Paginação Tests

        [Theory]
        [InlineData(1, 5)]
        [InlineData(2, 10)]
        [InlineData(3, 20)]
        public async Task ListarAsync_ComDiferentesPaginacoes_DeveRetornarCorretamente(int page, int pageSize)
        {
            // Arrange
            _repositoryMock.Setup(r => r.ListarAsync(page, pageSize))
                .ReturnsAsync((Enumerable.Empty<Publicacao>(), 0));

            // Act
            var result = await _service.ListarAsync(page, pageSize);

            // Assert
            result.Page.Should().Be(page);
            result.PageSize.Should().Be(pageSize);
            _repositoryMock.Verify(r => r.ListarAsync(page, pageSize), Times.Once);
        }

        #endregion
    }
}
