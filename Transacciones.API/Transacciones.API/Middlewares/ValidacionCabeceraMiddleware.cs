using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Transacciones.API.Middlewares
{
    
    
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ValidacionCabeceraMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidacionCabeceraMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if (!context.Request.Headers.TryGetValue("X-App-Client", out var valorCabecera) || valorCabecera != "MiAplicacion")
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Cabecera 'X-App-Client' inválida o ausente.");
                return;
            }

            // Si la cabecera es válida, continúa el flujo
            await _next(context);
        }

    }

 
    /*public static class ValidacionCabeceraMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidacionCabeceraMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidacionCabeceraMiddleware>();
        }
    } */

}
