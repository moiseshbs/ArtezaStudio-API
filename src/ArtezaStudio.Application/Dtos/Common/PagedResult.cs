namespace ArtezaStudio.Application.Dtos.Common
{
    /// <summary>
    /// Paginação de resultados genéricos
    /// </summary>
    /// <typeparam name="T">Tipo dos itens paginados</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Itens da página atual
        /// </summary>
        public IEnumerable<T> Items { get; set; } = [];

        /// <summary>
        /// Total de itens disponíveis
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Número da página atual
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Tamanho da página
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total de páginas disponíveis
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        /// <summary>
        /// Indica se há uma página anterior
        /// </summary>
        public bool HasPreviousPage => Page > 1;
        
        /// <summary>
        /// Indica se há uma próxima página
        /// </summary>
        public bool HasNextPage => Page < TotalPages;
    }
}