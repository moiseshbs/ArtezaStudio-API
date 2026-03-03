namespace ArtezaStudio.Application.Dtos.Common
{
    /// <summary>
    /// Parametros de paginação para consultas paginadas.
    /// </summary>
    public class PaginationParams
    {
        /// <summary>
        /// Tamanho máximo da página permitido.
        /// </summary>
        private const int MaxPageSize = 50;
        
        /// <summary>
        /// Tamanho da página atual.
        /// </summary>
        private int _pageSize = 10;

        /// <summary>
        /// Número da página atual.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Tamanho da página.
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}