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
    public class MeserosController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public MeserosController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var meseros = dataContext.Mesero.ToList();
            var meserosDTO = meseros.Select(x => mapper.Map<MeseroDTO>(x)).OrderByDescending(x => x.IdMesero);
            //return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = meserosDTO, Message = "Se retorno la información con exíto" });
            return Ok(meserosDTO);
        }
        [HttpPost]
        public IActionResult Post(MeseroDTO meseroDTO)
        {
            meseroDTO.IdMesero = null;
            meseroDTO.Nombres = meseroDTO.Nombres.ToString().TrimEnd();
            meseroDTO.Apellidos = meseroDTO.Apellidos.ToString().TrimEnd();
            if (!(meseroDTO.Edad >= 18))
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = "El mesero debe ser mayor de edad para ser ingresado en el sistema" });
            }
            else if (meseroDTO.Antiguedad_x_Anio < 0)
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = "El valor de la antiguedad no es valido"});
            }
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = string.Join(",", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) });

                var mesero = dataContext.Mesero.Add(mapper.Map<Mesero>(meseroDTO)).Entity;
                dataContext.SaveChanges();
                meseroDTO.IdMesero = mesero.IdMesero;
                return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = meseroDTO, Message = "Se ingreso la información con exíto" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }
    }
}
