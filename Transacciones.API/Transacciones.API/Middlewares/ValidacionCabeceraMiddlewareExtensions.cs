using Microsoft.AspNetCore.Builder;

namespace Transacciones.API.Middlewares
{
    public static class ValidacionCabeceraMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidacionCabeceraMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidacionCabeceraMiddleware>();
        }

    }
}
