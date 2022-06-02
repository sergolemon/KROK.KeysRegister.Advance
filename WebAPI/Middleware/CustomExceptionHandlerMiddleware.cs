using Application.Exceptions;
using Application.ResponseDTO;
using FluentValidation;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace WebAPI.Middleware
{
    internal class CustomExceptionHandlerMiddleware
    {
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
            _context = null!;
        }

        private readonly RequestDelegate _next;
        private HttpContext _context;

        public async Task InvokeAsync(HttpContext context)
        {
            _context = context;

            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                await ExceptionHandleAsync(exception);
            }
        }

        private async Task ExceptionHandleAsync(Exception exception)
        {
            switch (exception)
            {
                case ConflictException conflictException: 
                    {
                        await ResponseBuildAsync(
                            StatusCodes.Status409Conflict, 
                            conflictException.Message
                        );

                        break;
                    }
                case NotFoundException notFoundException:
                    {
                        await ResponseBuildAsync(
                            StatusCodes.Status404NotFound,
                            notFoundException.Message
                        );

                        break;
                    }
                case ValidationException validationException:
                    {
                        await ResponseBuildAsync(
                            StatusCodes.Status400BadRequest,
                            validationException.Errors
                            .Select(error => new 
                            { 
                                error.PropertyName, 
                                error.ErrorMessage 
                            })
                        );

                        break;
                    }
                default:
                    {
                        await ResponseBuildAsync(StatusCodes.Status500InternalServerError);
                        break;
                    }
            }
        }

        private async Task ResponseBuildAsync(int statusCode, object? body = null)
        {
            _context.Response.ContentType = "application/json;charset=utf-8";
            _context.Response.StatusCode = statusCode;
            await _context.Response.WriteAsJsonAsync(body);
        }
    }
}
