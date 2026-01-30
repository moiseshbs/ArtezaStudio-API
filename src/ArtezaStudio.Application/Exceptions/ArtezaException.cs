using System.Net;

namespace ArtezaStudio.Application.Exceptions
{
    public class ArtezaException : Exception
    {
        public int CodigoErro { get; }
        public HttpStatusCode StatusCode { get; }
        public Dictionary<string, string[]>? Erros { get; }

        public ArtezaException(
            string mensagem,
            Enum codigoErro,
            HttpStatusCode statusCode,
            Dictionary<string, string[]>? erros = null)
            : base(mensagem)
        {
            CodigoErro = Convert.ToInt32(codigoErro);
            StatusCode = statusCode;
            Erros = erros;
        }

        public ArtezaException(
            string mensagem,
            Enum codigoErro,
            HttpStatusCode statusCode,
            Exception innerException,
            Dictionary<string, string[]>? erros = null)
            : base(mensagem, innerException)
        {
            CodigoErro = Convert.ToInt32(codigoErro);
            StatusCode = statusCode;
            Erros = erros;
        }
    }
}