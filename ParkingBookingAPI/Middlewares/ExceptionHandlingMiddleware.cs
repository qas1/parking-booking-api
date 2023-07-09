using Microsoft.AspNetCore.Mvc;
using ParkingBookingApi.Exceptions;
using System.Net;
using System.Text.Json;

namespace ParkingBookingApi.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                this.logger.LogError(e, e.Message);

                var exceptionType = e.GetType();
                var statusCode = (int)HttpStatusCode.InternalServerError;

                if (exceptionType.IsAssignableFrom(typeof(NotFoundException)))
                {
                    statusCode = (int)HttpStatusCode.NotFound;
                }
                else if (exceptionType.IsAssignableFrom(typeof(UnprocessableEntityException)))
                {
                    statusCode = (int)HttpStatusCode.UnprocessableEntity;
                }

                context.Response.StatusCode = statusCode;

                var problemDetails = new ProblemDetails
                {
                    Status = statusCode,
                    Detail = e.Message
                };

                var json = JsonSerializer.Serialize(problemDetails);

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);
            }
        }
    }
}
