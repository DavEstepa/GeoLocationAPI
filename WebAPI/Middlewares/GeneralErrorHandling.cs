using GeoLocationDemoAPI.WebAPI.Models;
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
                var error = new ExceptionResponse(e);
                var errorWrapper = new GeneralResponse<ExceptionResponse>
                {
                    Success = false,
                    Data = error,
                    Message = ""
                };
                string json = JsonSerializer.Serialize(errorWrapper);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);

            }
        }
    }
}
