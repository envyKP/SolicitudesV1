using Microsoft.Extensions.DependencyInjection;
using Transacciones.API.Aplicacion.Interfaces.Iservicio;
using Transacciones.API.Aplicacion.Servicios;

namespace Transacciones.API.Aplicacion
{
    public static class InyeccionDependencia
    {

        public static IServiceCollection AddService(this IServiceCollection services)
        {

            //SGA: registrO ITransaccionesServicio dentro del método AddService()
            services.AddScoped<ITransaccionesServicio, TransaccionesServicio>();
           
            //SGA: registrO IProductoProxyService dentro del método AddService()
            services.AddScoped<IProductoProxyService, ProductoProxyService>();


            //SGA: registrO IUsuarioService dentro del método AddService()
            services.AddScoped<IUsuarioService, UsuarioServices>();

            return services;

        }

    }
}
