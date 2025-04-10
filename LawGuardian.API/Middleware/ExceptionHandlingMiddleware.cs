﻿using Microsoft.Identity.Client;

namespace LawGuardian.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.GetType().ToString()}: {ex.Message}");

                if (ex.InnerException is not null)
                {
                    _logger.LogError($"{ex.InnerException.GetType().ToString()}:{ex.InnerException.Message}");
                }
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsJsonAsync(new { Message = ex.Message, Type = ex.GetType().ToString() });
            }



            
        }
    }
      public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }   
    }

}