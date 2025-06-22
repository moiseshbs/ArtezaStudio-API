using ArtezaStudio.Api.Entities;

namespace ArtezaStudio.Api.Repositories.Interfaces
{
    public interface IPublicacaoRepository
    {
        Task<IEnumerable<Publicacao>> ListarAsync();
        Task<Publicacao> CriarAsync(Publicacao publicacao);
        Task<Publicacao> ObterPorIdAsync(Guid id);
        Task<bool> ExcluirAsync(Guid id);
        Task<Publicacao> AtualizarAsync(Publicacao publicacao);
        Task AdicionarPublicacaoTagAsync(PublicacaoTag publicacaoTag);
    }
}
