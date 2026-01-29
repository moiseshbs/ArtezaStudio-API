using System.Net;
using System.Text.Json;
using ArtezaStudio.Api.Responses;

namespace ArtezaStudio.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro interno.");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = JsonSerializer.Serialize(ApiResponse<string>.Erro("Erro interno inesperado."));
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
