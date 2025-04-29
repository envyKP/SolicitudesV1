using Microsoft.Extensions.DependencyInjection;
using Solicitudes.API.Aplicacion.Interfaces.IServicios;
using Solicitudes.API.Aplicacion.Servicios;

namespace Solicitudes.API.Aplicacion
{
    public static class InyeccionDependencia
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {

            //SGA: registrO ITransaccionesServicio dentro del método AddService()
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddScoped<ISolicitudService, SolicitudService>();

            return services;
        }

    }
}
