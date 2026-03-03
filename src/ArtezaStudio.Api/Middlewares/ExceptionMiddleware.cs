using System.Net;
using System.Text.Json;
using ArtezaStudio.Api.Responses;
using ArtezaStudio.Application.Exceptions;
using ArtezaStudio.Domain.Enums;

namespace ArtezaStudio.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArtezaException ex)
            {
                _logger.LogWarning(ex, "ArtezaException: {CodigoErro} - {Mensagem}", ex.CodigoErro, ex.Message);
                await HandleArtezaExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro interno não tratado: {Mensagem}", ex.Message);
                await HandleUnhandledExceptionAsync(context, ex);
            }
        }

        private async Task HandleArtezaExceptionAsync(HttpContext context, ArtezaException exception)
        {
            context.Response.StatusCode = (int)exception.StatusCode;
            context.Response.ContentType = "application/json";

            var errorResponse = new ErrorResponse(
                exception.Message,
                exception.CodigoErro,
                (int)exception.StatusCode,
                exception.Erros
            );

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = _environment.IsDevelopment()
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, options));
        }

        private async Task HandleUnhandledExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var message = _environment.IsDevelopment()
                ? exception.Message
                : "Ocorreu um erro interno no servidor.";

            var errorResponse = new ErrorResponse(
                message,
                (int)ErrorCode.Geral.ErroInternoServidor,
                (int)HttpStatusCode.InternalServerError
            );

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = _environment.IsDevelopment()
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, options));
        }
    }
}