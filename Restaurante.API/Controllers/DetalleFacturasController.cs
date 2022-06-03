using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.BL.Data;
using Restaurante.BL.DTOs;
using Restaurante.BL.Models;
using System.Net;
using System.Web.Http.Description;

namespace Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturasController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public DetalleFacturasController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var detallefacturas = dataContext.Detalle_x_Factura.Include("Supervisor").ToList();
            var detallefacturaDTO = detallefacturas.Select(x => mapper.Map<Detalle_x_FacturaOutputDTO>(x));
            //return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = detallefacturaDTO, Message = "Se retorno la información con exíto" });
            return Ok(detallefacturaDTO);
        }
        [HttpPost]
        public IActionResult Post(Detalle_x_FacturaDTO detallefacturaDTO)
        {
            detallefacturaDTO.IdDetallexFactura = null;
            detallefacturaDTO.Plato = detallefacturaDTO.Plato.ToString().TrimEnd();
            if (detallefacturaDTO.Valor <= 0)
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = "El valor ingresado para el precio no es valido"});
            }
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = string.Join(",", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) });

                var detallefactura = dataContext.Detalle_x_Factura.Add(mapper.Map<Detalle_x_Factura>(detallefacturaDTO)).Entity;
                dataContext.SaveChanges();
                detallefacturaDTO.IdDetallexFactura = detallefactura.IdDetallexFactura;
                return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = detallefacturaDTO, Message = "Se ingreso la información con exíto" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }
    }
}
