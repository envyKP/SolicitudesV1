using AutoMapper;
using Solicitudes.API.Aplicacion.Interfaces.Interfaces;
using Solicitudes.API.Aplicacion.Interfaces.IServicios;
using Solicitudes.API.Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Aplicacion.Servicios
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



        public async Task<UsuarioDTO> consultaUsuarioPorID(int id)
        {
            try
            {
                // consulto la transaccion de la capa de repositorio
                var trxExistente = await _usuariosRepositorio.consultaUsuarioPorID(id);

                // Si no se encuentra retornar null
                if (trxExistente == null)
                {
                    return null;
                }
                // Mapear la entidad a DTO
                var UsuarioDto = _mapper.Map<UsuarioDTO>(trxExistente);

                return UsuarioDto;
            }
            catch (Exception ex)
            {
                // Manejo de error y retornando null si ocurre un fallo
                return null;
            }
        }
    }
}
