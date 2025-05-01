using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Aplicacion.Interfaces.Irepositorio;
using Transacciones.API.Aplicacion.Interfaces.Iservicio;
using Transacciones.API.Entidades.DTOs;



namespace Transacciones.API.Aplicacion.Servicios
{
    public class UsuarioServices : IUsuarioService
    {
        
        private readonly IusuarioRepositorio _IusuarioRepositorio;
        private readonly IMapper _mapper;



        public UsuarioServices ( IusuarioRepositorio IusuarioRepositorio, IMapper mapper)
        {
            _IusuarioRepositorio = IusuarioRepositorio;
            _mapper              = mapper;

        }


        public async Task<usuarioDTO> GetUsuarioRepositorio(int id)
        {
            var registroUsuario = await _IusuarioRepositorio.GetUsuarioRepositorio(id);

            if (registroUsuario == null) throw new KeyNotFoundException("Usuario no encontrado.");
            return _mapper.Map<usuarioDTO>(registroUsuario);
        }
    }
}
