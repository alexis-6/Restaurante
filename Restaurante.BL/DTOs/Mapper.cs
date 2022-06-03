using AutoMapper;
using Restaurante.BL.Models;

namespace Restaurante.BL.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Mesero, MeseroDTO>().ReverseMap();
            CreateMap<Supervisor, SupervisorDTO>().ReverseMap();
            CreateMap<Supervisor, SupervisorOutputDTO>().ReverseMap();
            CreateMap<Detalle_x_Factura, Detalle_x_FacturaDTO>().ReverseMap();
            CreateMap<Detalle_x_Factura, Detalle_x_FacturaOutputDTO>().ReverseMap();
            CreateMap<Factura, FacturaDTO>().ReverseMap();
            CreateMap<Mesa, MesaDTO>().ReverseMap();
        }
    }
}
