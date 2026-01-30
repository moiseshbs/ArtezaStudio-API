using ArtezaStudio.Application.Services.Interfaces;

namespace ArtezaStudio.Application.Services
{
    public class SenhaHashService : ISenhaHashService
    {
        public string HashSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("A senha não pode ser vazia.", nameof(senha));

            return BCrypt.Net.BCrypt.HashPassword(senha, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        public bool VerificarSenha(string senha, string hash)
        {
            if (string.IsNullOrWhiteSpace(senha))
                return false;

            if (string.IsNullOrWhiteSpace(hash))
                return false;

            try
            {
                return BCrypt.Net.BCrypt.Verify(senha, hash);
            }
            catch
            {
                return false;
            }
        }
    }
}