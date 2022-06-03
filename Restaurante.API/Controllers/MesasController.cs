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
    public class MesasController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public MesasController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var mesas = dataContext.Mesa.ToList();
            var mesasDTO = mesas.Select(x => mapper.Map<MesaDTO>(x)).OrderByDescending(x => x.NroMesa);
            //return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = mesasDTO, Message = "Se retorno la información con exíto" });
            return Ok(mesasDTO);
        }
        [HttpPost]
        public IActionResult Post(MesaDTO mesaDTO)
        {
            mesaDTO.NroMesa = null;
            mesaDTO.Nombre = mesaDTO.Nombre.ToString().TrimEnd();
            if (mesaDTO.Puestos <= 0)
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = "El valor de los puestos no es valido" });
            }
            
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = string.Join(",", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) });

                var mesa = dataContext.Mesa.Add(mapper.Map<Mesa>(mesaDTO)).Entity;
                dataContext.SaveChanges();
                mesaDTO.NroMesa = mesa.NroMesa;
                return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = mesaDTO, Message = "Se ingreso la información con exíto" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }
    }
}
