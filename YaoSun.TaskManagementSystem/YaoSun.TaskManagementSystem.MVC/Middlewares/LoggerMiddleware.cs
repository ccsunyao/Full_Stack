using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.Exceptions;

namespace YaoSun.TaskManagementSystem.MVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<LoggerMiddleware> _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Some Exception happened, caught in this middleware: ");

                await HandleException(httpContext, ex);
            }
        }
        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            // get the exception, log with serilog and send email to dev team

            _logger.LogError(" Starting Exception Logging: ");

            switch (ex)
            {
                case ConflictException conflictException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                case NotFoundException notFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case Exception exception:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var errorResponse = new
            {
                ExceptionMessage = ex.Message,
                InnerExceptionMessage = ex.InnerException,
                ExceptionStackStrace = ex.StackTrace
            };

            // Log above object with Serilog
            // send email to the Dev Team

            _logger.LogError("Exception Message: {0}", errorResponse.ExceptionMessage);
            _logger.LogError("Exception happened on {0}", DateTime.Now);
            _logger.LogError("StackTrace Of Exception {0}", errorResponse.ExceptionStackStrace);

            // redirect to a error page
            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}
