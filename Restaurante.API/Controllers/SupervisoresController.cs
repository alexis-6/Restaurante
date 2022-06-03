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
    public class SupervisoresController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public SupervisoresController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var supervisores = dataContext.Supervisor.ToList();
            var supervisoresDTO = supervisores.Select(x => mapper.Map<SupervisorDTO>(x)).OrderBy(x => x.IdSupervisor);
            //return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = supervisoresDTO, Message = "Se retorno la información con exíto" });
            return Ok(supervisoresDTO);
        }
        [HttpPost]
        public IActionResult Post(SupervisorDTO supervisorDTO)
        {
            supervisorDTO.IdSupervisor = null;
            supervisorDTO.Nombres = supervisorDTO.Nombres.ToString().TrimEnd();
            supervisorDTO.Apellidos = supervisorDTO.Apellidos.ToString().TrimEnd();
            if (!(supervisorDTO.Edad >= 18))
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = "El supervisor debe ser mayor de edad para ser ingresado en el sistema" });
            }
            else if (supervisorDTO.Antiguedad_x_Anio < 0)
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = "El valor de la antiguedad no es valido" });
            }
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.BadRequest, Message = string.Join(",", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) });

                var supervisor = dataContext.Supervisor.Add(mapper.Map<Supervisor>(supervisorDTO)).Entity;
                dataContext.SaveChanges();
                supervisorDTO.IdSupervisor = supervisor.IdSupervisor;
                return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = supervisorDTO, Message = "Se ingreso la información con exíto" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }
    }
}