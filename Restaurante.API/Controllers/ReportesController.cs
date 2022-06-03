using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Restaurante.BL.Data;
using Restaurante.BL.DTOs;
using System.Data;
using System.Net;
using System.Text.Json;

namespace Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public ReportesController(DataContext dataContext, IMapper mapper, IConfiguration configuration)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        [HttpGet]
        [Route("GetVentas")]
        public IActionResult GetAll(DateTime fechaInicial, DateTime fechaFinal)
        {
            using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("Connection")))
            {
                try
                {
                    DataTable table = new DataTable();
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("Sp_Ventas_x_Mesero", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fechaInicial", fechaInicial.ToString("yyyy-MM-dd")));
                    cmd.Parameters.Add(new SqlParameter("@fechaFinal", fechaFinal.ToString("yyyy-MM-dd")));
                    var dataReader = cmd.ExecuteReader();
                    table.Load(dataReader);
                    string json = JsonConvert.SerializeObject(table, Formatting.Indented);
                    return Ok(json);
                }
                catch (Exception ex)
                {
                    return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
                }
            }
        }
        [HttpGet]
        [Route("GetConsumoClientes")]
        public IActionResult GetAllConsumo(decimal valor, DateTime fechaInicial, DateTime fechaFinal)
        {
            using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("Connection")))
            {
                try
                {
                    DataTable table = new DataTable();
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("Sp_ConsumoClientes", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fechaInicial", fechaInicial.ToString("yyyy-MM-dd")));
                    cmd.Parameters.Add(new SqlParameter("@fechaFinal", fechaFinal.ToString("yyyy-MM-dd")));
                    cmd.Parameters.Add(new SqlParameter("@valor", valor));
                    var dataReader = cmd.ExecuteReader();
                    table.Load(dataReader);
                    string json = JsonConvert.SerializeObject(table, Formatting.Indented);
                    return Ok(json);
                }
                catch (Exception ex)
                {
                    return BadRequest(new RespuestaDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
                }
            }
        }
    }
}
