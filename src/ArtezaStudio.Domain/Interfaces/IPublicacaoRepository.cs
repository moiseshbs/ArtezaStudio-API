using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Domain.Interfaces
{
    public interface IPublicacaoRepository
    {
        Task<IEnumerable<Publicacao>> ListarAsync();
        Task<IEnumerable<Publicacao>> ListarPorUsuarioIdAsync(long usuarioId);
        Task<IEnumerable<Publicacao>> ListarPorTagIdAsync(long tagId);
        Task<IEnumerable<Publicacao>> ListarPorTermoAsync(string termo);
        Task<Publicacao> CriarAsync(Publicacao publicacao);
        Task<Publicacao> ObterPorIdAsync(long id);
        Task<bool> ExcluirAsync(long id);
        Task<Publicacao> AtualizarAsync(Publicacao publicacao);
        Task AdicionarPublicacaoTagAsync(PublicacaoTag publicacaoTag);
    }
}
