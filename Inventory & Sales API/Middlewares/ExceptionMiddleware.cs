using InventorySales.Application.Exceptions;
using InventorySales.Application.Responses;
using System.Text.Json;

namespace Inventory___Sales_API.Middlewares {
    public class ExceptionMiddleware {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            try {
                await _next(context);
            }
            catch (Exception exception) {
                await HandleExceptionAsync(context, exception);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext context,Exception exception) {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch {
                NotFoundException => StatusCodes.Status404NotFound,
                ConflictException => StatusCodes.Status409Conflict,
                BadRequestException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;

            var response = CreateResponse(statusCode, exception.Message);

            await context.Response.WriteAsJsonAsync(response);
        }

        private static ErrorResponse CreateResponse(int statusCode, string message) {
            return new ErrorResponse {
                StatusCode = statusCode,
                Message = message
            };
        }
    }

}
