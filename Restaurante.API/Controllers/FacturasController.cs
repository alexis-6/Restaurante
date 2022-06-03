using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.BL.Data;
using Restaurante.BL.DTOs;
using Restaurante.BL.Models;
using System.Net;

namespace Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public FacturasController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var facturas = dataContext.Factura.ToList();
            var facturasDTO = facturas.Select(x => mapper.Map<FacturaDTO>(x)).OrderBy(x => x.NroFactura);
            //return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = facturasDTO, Message = "Se retorno la información con exíto" });
            return Ok(facturasDTO);
        }
        [HttpPost]
        public IActionResult Post(FacturaDTO facturaDTO)
        {
            facturaDTO.NroFactura = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = string.Join(",", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) });

                var factura = dataContext.Factura.Add(mapper.Map<Factura>(facturaDTO)).Entity;
                dataContext.SaveChanges();
                facturaDTO.NroFactura = factura.NroFactura;
                return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = facturaDTO, Message = "Se ingreso la información con exíto" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }
    }
}
