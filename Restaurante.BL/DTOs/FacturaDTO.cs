using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.BL.DTOs
{
    public class FacturaDTO
    {
        [JsonProperty("NroFactura")]
        [Required(ErrorMessage = "El campo NroFactura es requerido")]
        public int? NroFactura { get; set; }
        [JsonProperty("IdCliente")]
        [Required(ErrorMessage = "El campo IdCliente es requerido")]
        [StringLength(10)]
        public string IdCliente { get; set; }
        [JsonProperty("NroMesa")]
        [Required(ErrorMessage = "El campo NroMesa es requerido")]
        public int NroMesa { get; set; }
        [JsonProperty("IdMesero")]
        [Required(ErrorMessage = "El campo IdMesero es requerido")]
        public int IdMesero { get; set; }
        [JsonProperty("Fecha")]
        [Required(ErrorMessage = "El campo Fecha es requerido")]
        public DateTime Fecha { get; set; }
    }
}
