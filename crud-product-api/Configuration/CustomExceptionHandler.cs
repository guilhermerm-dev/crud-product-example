using System.Net;
using System.Text.Json;
using crud_product_domain.Error;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace crud_product_api.Configuration
{
    public class CustomExceptionHandler
    {
        public static void HandleErrors(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                context.Response.ContentType = "application/json";

                if (exceptionHandlerPathFeature?.Error is ProductAlreadyExistsException)
                {
                    context.Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                    await context.Response.WriteAsync(JsonSerializer.Serialize(
                            CreateErrorObject(exceptionHandlerPathFeature?.Error.Message
                            , context.Response.StatusCode)));
                }
            });
        }

        private static object CreateErrorObject(string message, int httpStatusCode)
        {
            return new
            {
                Message = message,
                HttpStatusCode = httpStatusCode
            };
        }

    }
}
