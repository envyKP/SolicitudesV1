using Microsoft.Extensions.DependencyInjection;
using Transacciones.API.Aplicacion.Interfaces.Irepositorio;
using Transacciones.API.Infraestructura.Repositorios;

namespace Transacciones.API.Infraestructura
{
    public static class InyecccionDependencia
    {

        public static IServiceCollection AddInfrastructura(this IServiceCollection services)
        {
            services.AddScoped<ITransaccionesRepositorio, TransaccionesRepositorio>();
            services.AddScoped<IusuarioRepositorio, UsuarioRepositorio>();

            return services;
        }

    }
}
