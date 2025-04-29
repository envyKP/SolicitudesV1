using Solicitudes.API.Entidades.DTOs;
using Solicitudes.API.Entidades.Entities;
using AutoMapper;

namespace Solicitudes.API.Entidades.Mapper
{
    public class SolicitudMapper : Profile
    {
        public SolicitudMapper()
        {
            // Mapeo de la entidad TBL_SOLICITUD a DTO
            CreateMap<TBL_SOLICITUD, SolicitudDTO>()
                //.ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.DESCRIPCION, opt => opt.MapFrom(src => src.DESCRIPCION))
                .ForMember(dest => dest.MONTO, opt => opt.MapFrom(src => src.MONTO))
                .ForMember(dest => dest.FECHA_ESPERADA, opt => opt.MapFrom(src => src.FECHA_ESPERADA))
                .ForMember(dest => dest.ESTADO, opt => opt.MapFrom(src => src.ESTADO))
                .ForMember(dest => dest.COMENTARIO, opt => opt.MapFrom(src => src.COMENTARIO))
                .ReverseMap();  // Para permitir la conversión inversa si es necesario
        }
    }
}
