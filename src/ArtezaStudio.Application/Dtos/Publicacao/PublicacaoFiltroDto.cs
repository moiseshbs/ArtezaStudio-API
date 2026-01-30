using System.ComponentModel.DataAnnotations;

namespace ArtezaStudio.Application.Dtos.Publicacao
{
    /// <summary>
    /// DTO para criar e atualizar publicações.
    /// </summary>
    public class PublicacaoFiltroDto
    {
        /// <summary>
        /// Identificador da publicação.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Título da publicação.
        /// </summary>
        [Required]
        public required string Titulo { get; set; }

        /// <summary>
        /// Descrição da publicação.
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// URL da imagem da publicação.
        /// </summary>
        [Required]
        public required string ImagemUrl { get; set; }

        /// <summary>
        /// Identificador do usuário associado à publicação.
        /// </summary>
        [Required]
        public long UsuarioId { get; set; }

        /// <summary>
        /// Lista de identificadores de tags associadas à publicação.
        /// </summary>
        public List<long>? TagIds { get; set; }
    }
}
