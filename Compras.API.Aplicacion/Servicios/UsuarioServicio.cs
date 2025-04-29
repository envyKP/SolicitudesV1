using AutoMapper;
using Compras.API.Aplicacion.Interfaces.Interfaces;
using Compras.API.Aplicacion.Interfaces.IServicios;
using Compras.API.Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compras.API.Aplicacion.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        private readonly IMapper _mapper;
        public UsuarioServicio(IUsuariosRepositorio usuariosRepositorio,
                              IMapper mapper)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _mapper = mapper;
        }
        public async Task<UsuarioDto> GetTransaccion(int id)
        {
            try
            {
                // consulto la transaccion de la capa de repositorio
                var trxExistente = await _usuariosRepositorio.GetTransaccion(id);

                // Si no se encuentra retornar null
                if (trxExistente == null)
                {
                    return null;
                }
                // Mapear la entidad a DTO
                var transaccionDto = _mapper.Map<UsuarioDto>(trxExistente);
                return transaccionDto;
            }
            catch (Exception ex)
            {
                // Manejo de error y retornando null si ocurre un fallo
                return null;
            }
        }
    }
}
