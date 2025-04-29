using AutoMapper;
using Solicitudes.API.Entidades.DTOs;
using Solicitudes.API.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Entidades.Mapper
{
    public class configMapper : Profile
    {
        public  configMapper() 
        {
            CreateMap<TBL_USUARIO, UsuarioDTO>()
                // DTO                          VS    TABLA
                .ForMember(dest => dest.ID,       opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.NOMBRES,  opt => opt.MapFrom(src => src.NOMBRES))
                .ForMember(dest => dest.USERNAME, opt => opt.MapFrom(src => src.USERNAME))
                .ForMember(dest => dest.ROL_ID,   opt => opt.MapFrom(src => src.ROL_ID))
                .ForMember(dest => dest.TELEFONO, opt => opt.MapFrom(src => src.TELEFONO))
                .ForMember(dest => dest.CORREO,   opt => opt.MapFrom(src => src.CORREO))
                .ReverseMap();



        }

    }
}
