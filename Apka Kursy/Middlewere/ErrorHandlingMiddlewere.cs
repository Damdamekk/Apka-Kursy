﻿using Apka_Kursy.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.Logging;

namespace Apka_Kursy.Middlewere
{
    public class ErrorHandlingMiddlewere : IMiddleware
    {
        private readonly ILogger _logger;

        public ErrorHandlingMiddlewere(ILogger<ErrorHandlingMiddlewere> logger) 
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (DatabaseSavingException databaseSavingException)
            {
                context.Response.StatusCode = 422;
                await context.Response.WriteAsync(databaseSavingException.Message);
            }
            catch (Exception e) 
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }

}
