using Microsoft.Extensions.DependencyInjection;
using Solicitudes.API.Aplicacion.Interfaces.Interfaces;
using Solicitudes.API.Aplicacion.Interfaces.IRepositorios;
using Solicitudes.API.Infraestructura.Repositorios;

namespace Solicitudes.API.Infraestructura
{
    public static class InyeccionDependencia
    {
        public static IServiceCollection AddInfrastructura(this IServiceCollection services)
        {
            services.AddScoped<IUsuariosRepositorio, UsuarioRepositorio>();
            services.AddScoped<ISolicitudRepositorio, SolicitudRepositorio>();

            return services;
        }

    }
}
