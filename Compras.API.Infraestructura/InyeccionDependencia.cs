using Compras.API.Aplicacion.Interfaces.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Compras.API.Aplicacion;
 


namespace Compras.API.Infraestructura
{
    public static class InyeccionDependencia
    {
        public static IServiceCollection AddInfrastructura(this IServiceCollection services)
        {
            services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();

            return services;
        }
    }
}
