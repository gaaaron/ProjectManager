using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectManager.Model.Exceptions;
using System.Threading.Tasks;

namespace ProjectManager.RestApi.Configurations
{
    public static class ProjectManagerExceptionHandler
    {
        public static async Task HandleException(this HttpContext context, ILogger logger)
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature.Error;

            logger.LogError(exception, exceptionHandlerPathFeature.Path);

            if (exception is EntityNotFoundException)
            {
                await context.Response.WriteAsync("Entity not found!");
                return;
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }
    }
}
