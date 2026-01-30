namespace ArtezaStudio.Domain.Enums
{
    public static class ErrorCode
    {
        public enum Geral
        {
            ErroInternoServidor = 1000,
            ErroValidacao = 1001,
            ErroRegraNegocio = 1002
        }

        public enum Autenticacao
        {
            CredenciaisInvalidas = 2000,
            NaoAutorizado = 2001,
            TokenExpirado = 2002,
            TokenInvalido = 2003
        }

        public enum Usuario
        {
            UsuarioNaoEncontrado = 3000,
            UsuarioJaExiste = 3001,
            EmailJaExiste = 3002,
            UsernameJaExiste = 3003,
            UsuarioInativo = 3004
        }

        public enum Publicacao
        {
            PublicacaoNaoEncontrada = 4000,
            PublicacaoAcessoNegado = 4001
        }

        public enum Comentario
        {
            ComentarioNaoEncontrado = 5000,
            ComentarioAcessoNegado = 5001
        }

        public enum Curtida
        {
            CurtidaNaoEncontrada = 6000,
            CurtidaJaExiste = 6001
        }

        public enum Tag
        {
            TagNaoEncontrada = 7000,
            TagJaExiste = 7001
        }

        public enum Seguidor
        {
            SeguidorJaExiste = 8000,
            SeguidorNaoEncontrado = 8001,
            NaoPodeSeguirSiMesmo = 8002
        }

        public enum Visualizacao
        {
            VisualizacaoNaoEncontrada = 9000
        }
    }
}