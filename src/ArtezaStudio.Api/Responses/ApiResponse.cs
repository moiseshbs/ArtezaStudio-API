namespace ArtezaStudio.Api.Responses
{
    public class ApiResponse<T>
    {
        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; }
        public T? Dados { get; set; }
        public int? CodigoErro { get; set; }
        public Dictionary<string, string[]>? Erros { get; set; }

        public static ApiResponse<T> Ok(T dados, string? mensagem = null)
        {
            return new ApiResponse<T>
            {
                Sucesso = true,
                Mensagem = mensagem,
                Dados = dados
            };
        }

        public static ApiResponse<T> Erro(string mensagem, int? codigoErro = null, Dictionary<string, string[]>? erros = null)
        {
            return new ApiResponse<T>
            {
                Sucesso = false,
                Mensagem = mensagem,
                CodigoErro = codigoErro,
                Dados = default,
                Erros = erros
            };
        }
    }
}