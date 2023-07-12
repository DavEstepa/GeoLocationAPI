using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace GeoLocationDemoAPI.WebAPI.Middlewares
{
    public class GeneralErrorHandling : IMiddleware
    {
        private readonly ILogger<GeneralErrorHandling> _logger;
        public GeneralErrorHandling(ILogger<GeneralErrorHandling> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ProblemDetails errorResponse = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "",
                    Title = "",
                    Detail = ""
                };

                string json = JsonSerializer.Serialize(errorResponse);

                await context.Response.WriteAsync(json);

                context.Response.ContentType = "application/json";
            }
        }
    }
}
