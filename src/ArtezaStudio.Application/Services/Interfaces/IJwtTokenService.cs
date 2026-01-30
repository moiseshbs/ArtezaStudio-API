using ArtezaStudio.Domain.Entities;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GerarToken(Usuario usuario);
        long? ValidarToken(string token);
    }
}