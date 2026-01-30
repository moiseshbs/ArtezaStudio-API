using ArtezaStudio.Application.Dtos.Common;
using ArtezaStudio.Application.Dtos.Publicacao;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface IPublicacaoService
    {
        /// <summary>
        /// Lista todas as publicações com paginação
        /// </summary>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Resultado paginado de PublicacaoDto</returns>
        Task<PagedResult<PublicacaoDto>> ListarAsync(int page = 1, int pageSize = 10);

        /// <summary>
        /// Lista publicações por ID do usuário com paginação
        /// </summary>
        /// <param name="usuarioId">Identificador do usuário</param>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Resultado paginado de PublicacaoDto</returns>
        Task<PagedResult<PublicacaoDto>> ListarPorUsuarioIdAsync(long usuarioId, int page = 1, int pageSize = 10);

        /// <summary>
        /// Lista publicações por ID da tag com paginação
        /// </summary>
        /// <param name="tagId">Identificador da tag</param>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Resultado paginado de PublicacaoDto</returns>
        Task<PagedResult<PublicacaoDto>> ListarPorTagIdAsync(long tagId, int page = 1, int pageSize = 10);

        /// <summary>
        /// Lista publicações por termo de busca com paginação
        /// </summary>
        /// <param name="termo">Termo de busca</param>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Resultado paginado de PublicacaoDto</returns>
        Task<PagedResult<PublicacaoDto>> ListarPorTermoAsync(string termo, int page = 1, int pageSize = 10);

        /// <summary>
        /// Cria uma nova publicação
        /// </summary>
        /// <param name="publicacaoFiltroDto">Dados para criar a publicação</param>
        /// <returns>PublicacaoDto criada</returns>
        Task<PublicacaoDto> CriarAsync(PublicacaoFiltroDto publicacaoFiltroDto);

        /// <summary>
        /// Obtém uma publicação por ID
        /// </summary>
        /// <param name="id">Identificador da publicação</param>
        /// <returns>PublicacaoDto correspondente ao ID</returns>
        Task<PublicacaoDto> ObterPorIdAsync(long id);

        /// <summary>
        /// Exclui uma publicação por ID
        /// </summary>
        /// <param name="id">Identificador da publicação</param>
        /// <returns>Indica se a exclusão foi bem-sucedida</returns>
        Task<bool> ExcluirAsync(long id);
        
        /// <summary>
        /// Atualiza uma publicação existente
        /// </summary>
        /// <param name="publicacaoFiltroDto">Dados para atualizar a publicação</param>
        /// <returns>PublicacaoDto atualizada</returns>
        Task<PublicacaoDto> AtualizarAsync(PublicacaoFiltroDto publicacaoFiltroDto);
    }
}