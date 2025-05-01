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
    public class ConfiguracionAutoMapper : Profile
    {

        public ConfiguracionAutoMapper()
        {
            CreateMap<TBL_TRANSACCIONE, TransaccionesDTO>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID_TRX))
                .ForMember(dest => dest.IdProducto, opt => opt.MapFrom(src => src.ID_PRODUCTO))
                .ForMember(dest => dest.fecha, opt => opt.MapFrom(src => src.FECHA))
                .ForMember(dest => dest.TipoTrx, opt => opt.MapFrom(src => src.TIPO_TRX))
                .ForMember(dest => dest.cantidad, opt => opt.MapFrom(src => src.CANTIDAD))
                .ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.PRECIO_UNITARIO))
                //.ForMember(dest => dest.PrecioTotal,    opt => opt.MapFrom(src => src.PRECIO_TOTAL))
                .ForMember(dest => dest.DetalleTrx, opt => opt.MapFrom(src => src.DETALLE_TRX))
                .ReverseMap();
        }
    }

}
