using Microsoft.Extensions.DependencyInjection;
using Compras.API.Aplicacion;
using Compras.API.Aplicacion.Interfaces.Interfaces;
using Compras.API.Infraestructura.Context;
using Compras.API.Entidades.Entities;
using Microsoft.EntityFrameworkCore;



namespace Compras.API.Infraestructura
{
    public  class  UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly ComprasDevContextBD _contextSolicitudes;

        public UsuariosRepositorio(ComprasDevContextBD context)
        {
            _contextSolicitudes = context;
        }

        public async Task<Usuario> GetTransaccion(int id)
        {
            // Buscamos la transacci�n por su ID_TRX
            return await _contextSolicitudes.Usuarios.FirstOrDefaultAsync(t => t.id == id);
        }
    }

}
