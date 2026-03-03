using System.ComponentModel.DataAnnotations;
using ArtezaStudio.Application.Dtos.Tag;
using ArtezaStudio.Application.Dtos.Usuario;

namespace ArtezaStudio.Application.Dtos.Publicacao
{
    /// <summary>
    /// Data Transfer Object para Publicacao
    /// </summary>
    public class PublicacaoDto
    {
        /// <summary>
        /// Identificador da publicação
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Título da publicação
        /// </summary>
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Descrição da publicação
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// URL da imagem da publicação
        /// </summary>
        public string ImagemUrl { get; set; } = string.Empty;

        /// <summary>
        /// Data da publicação
        /// </summary>
        public DateTime DataPublicacao { get; set; }

        /// <summary>
        /// Total de comentários na publicação
        /// </summary>
        public int TotalComentarios { get; set; }

        /// <summary>
        /// Total de curtidas na publicação
        /// </summary>
        public int TotalCurtidas { get; set; }

        /// <summary>
        /// Total de visualizações na publicação
        /// </summary>
        public int TotalVisualizacoes { get; set; }

        /// <summary>
        /// Tags associadas à publicação
        /// </summary>
        public ICollection<PublicacaoTagDto>? PublicacaoTags { get; set; }

        /// <summary>
        /// Identificador do usuário que criou a publicação
        /// </summary>
        public long UsuarioId { get; set; }
        
        /// <summary>
        /// Usuário que criou a publicação
        /// </summary>
        public UsuarioDto? Usuario { get; set; }
    }
}
