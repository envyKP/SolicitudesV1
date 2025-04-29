using Compras.API.Aplicacion.Interfaces.IServicios;
using Compras.API.Aplicacion.Servicios;
using Microsoft.Extensions.DependencyInjection;

namespace Compras.API.Aplicacion
{
    public static class InyeccionDependencia
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {

            //SGA: registrO ITransaccionesServicio dentro del método AddService()
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            return services;
        }
    }
}
