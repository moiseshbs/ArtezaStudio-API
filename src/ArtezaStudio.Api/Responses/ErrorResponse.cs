namespace ArtezaStudio.Api.Responses
{
    public class ErrorResponse
    {
        public bool Sucesso { get; set; } = false;
        public string Mensagem { get; set; }
        public int CodigoErro { get; set; }
        public int StatusCode { get; set; }
        public Dictionary<string, string[]>? Erros { get; set; }
        public DateTime DataHora { get; set; } = DateTime.UtcNow;

        public ErrorResponse(string mensagem, int codigoErro, int statusCode, Dictionary<string, string[]>? erros = null)
        {
            Mensagem = mensagem;
            CodigoErro = codigoErro;
            StatusCode = statusCode;
            Erros = erros;
        }
    }
}