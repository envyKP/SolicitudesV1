using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Entidades.DTOs;
using Transacciones.API.Entidades.Entities;

namespace Transacciones.API.Entidades.Mapper
{
    public class usuarioMappers : Profile
    {
        public usuarioMappers() 
        {
            CreateMap<TBL_USUARIO, usuarioDTO>()
                .ForMember(dest => dest.Idusuario,  opt => opt.MapFrom(src => src.id_usuario))
                .ForMember(dest => dest.Nombre,     opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Estado,     opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Rol,        opt => opt.MapFrom(src => src.Rol))
                .ReverseMap();
        }

    }

}
