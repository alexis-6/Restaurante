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
    public class ClientesController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public ClientesController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var clientes = dataContext.Cliente.ToList();
            var clientesDTO = clientes.Select(x => mapper.Map<ClienteDTO>(x)).OrderByDescending(x => x.Identificacion);
            //return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = clientesDTO, Message = "Se retorno la información con exíto" });
            return Ok(clientesDTO);
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ClienteDTO clienteDTO)
        {
            clienteDTO.Identificacion = clienteDTO.Identificacion.ToString().Trim();
            clienteDTO.Nombres = clienteDTO.Nombres.ToString().TrimEnd();
            clienteDTO.Apellidos = clienteDTO.Apellidos.ToString().TrimEnd();
            clienteDTO.Direccion = clienteDTO.Direccion.ToString().TrimEnd();
            clienteDTO.Telefono = clienteDTO.Telefono.ToString().Trim();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new RespuestaDTO{Code = (int)HttpStatusCode.BadRequest,Message = string.Join(",", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))});

                var cliente = dataContext.Cliente.Add(mapper.Map<Cliente>(clienteDTO)).Entity;
                dataContext.SaveChanges();
                clienteDTO.Identificacion = cliente.Identificacion;
                return Ok(new RespuestaDTO { Code = (int)HttpStatusCode.OK, Data = clienteDTO, Message = "Se ingreso la información con exíto" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }
    }
}
