namespace ArtezaStudio.Application.Services.Interfaces
{
    public interface ISenhaHashService
    {
        /// <summary>
        /// Gera o hash da senha fornecida.
        /// </summary>
        /// <param name="senha">A senha a ser hasheada.</param>
        /// <returns>O hash da senha.</returns>
        string HashSenha(string senha);

        /// <summary>
        /// Verifica se a senha fornecida corresponde ao hash.
        /// </summary>
        /// <param name="senha">A senha a ser verificada.</param>
        /// <param name="hash">O hash para comparação.</param>
        /// <returns>True se a senha corresponder ao hash; caso contrário, false.</
        bool VerificarSenha(string senha, string hash);
    }
}