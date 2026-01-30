using ArtezaStudio.Application.Dtos.Auth;
using ArtezaStudio.Application.Dtos.Usuario;

namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest);
        Task<LoginResponseDto> RegistrarAsync(RegistroRequestDto registroRequest);
    }
}