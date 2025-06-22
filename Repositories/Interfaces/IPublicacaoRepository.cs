using ArtezaStudio.Api.Entities;

namespace ArtezaStudio.Api.Repositories.Interfaces
{
    public interface IPublicacaoRepository
    {
        Task<IEnumerable<Publicacao>> ListarAsync();
        Task<IEnumerable<Publicacao>> ListarPorUsuarioIdAsync(Guid usuarioId);
        Task<IEnumerable<Publicacao>> ListarPorTagIdAsync(Guid tagId);
        Task<IEnumerable<Publicacao>> ListarPorTermoAsync(string termo);
        Task<Publicacao> CriarAsync(Publicacao publicacao);
        Task<Publicacao> ObterPorIdAsync(Guid id);
        Task<bool> ExcluirAsync(Guid id);
        Task<Publicacao> AtualizarAsync(Publicacao publicacao);
        Task AdicionarPublicacaoTagAsync(PublicacaoTag publicacaoTag);
    }
}
