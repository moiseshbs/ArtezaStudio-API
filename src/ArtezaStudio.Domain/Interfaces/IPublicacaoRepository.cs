using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Domain.Interfaces
{
    public interface IPublicacaoRepository
    {
        /// <summary>
        /// Listar publicações com paginação
        /// </summary>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Resultado paginado de Publicacao</returns>
        Task<(IEnumerable<Publicacao> Items, int TotalCount)> ListarAsync(int page, int pageSize);

        /// <summary>
        /// Listar publicações por ID do usuário com paginação
        /// </summary>
        /// <param name="usuarioId">Identificador do usuário</param>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Resultado paginado de Publicacao</returns>
        Task<(IEnumerable<Publicacao> Items, int TotalCount)> ListarPorUsuarioIdAsync(long usuarioId, int page, int pageSize);

        /// <summary>
        /// Listar publicações por ID da tag com paginação
        /// </summary>
        /// <param name="tagId">Identificador da tag</param>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Resultado paginado de Publicacao</returns> 
        Task<(IEnumerable<Publicacao> Items, int TotalCount)> ListarPorTagIdAsync(long tagId, int page, int pageSize);

        /// <summary>
        /// Listar publicações por termo com paginação
        /// </summary>
        /// <param name="termo">Termo de busca</param>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Tamanho da página</param>
        /// <returns>Resultado paginado de Publicacao</returns>
        Task<(IEnumerable<Publicacao> Items, int TotalCount)> ListarPorTermoAsync(string termo, int page, int pageSize);

        /// <summary>
        /// Criar uma nova publicação
        /// </summary>
        /// <param name="publicacao">Objeto Publicacao a ser criado</param>
        /// <returns>Publicacao criada</returns>
        Task<Publicacao> CriarAsync(Publicacao publicacao);

        /// <summary>
        /// Obter publicação por ID
        /// </summary>
        /// <param name="id">Identificador da publicação</param>
        /// <returns>Publicacao encontrada ou null</returns>
        Task<Publicacao?> ObterPorIdAsync(long id);

        /// <summary>
        /// Excluir publicação por ID
        /// </summary>
        /// <param name="id">Identificador da publicação</param>
        /// <returns>Indica se a exclusão foi bem-sucedida</returns>
        Task<bool> ExcluirAsync(long id);

        /// <summary>
        /// Atualizar uma publicação existente
        /// </summary>
        /// <param name="publicacao">Objeto Publicacao a ser atualizado</param>
        /// <returns>Publicacao atualizada</returns>
        Task<Publicacao> AtualizarAsync(Publicacao publicacao);

        /// <summary>
        /// Adicionar uma tag a uma publicação
        /// </summary>
        /// <param name="publicacaoTag">Objeto PublicacaoTag a ser adicionado</param>
        Task AdicionarPublicacaoTagAsync(PublicacaoTag publicacaoTag);
    }
}