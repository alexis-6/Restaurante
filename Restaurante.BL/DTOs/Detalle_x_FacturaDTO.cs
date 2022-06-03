using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.BL.DTOs
{
    public class Detalle_x_FacturaDTO
    {
        [JsonProperty("IdDetallexFactura")]
        public int? IdDetallexFactura { get; set; }
        [JsonProperty("NroFactura")]
        [Required(ErrorMessage = "El campo NroFactura es requerido")]
        public int NroFactura { get; set; }
        [JsonProperty("IdSupervisor")]
        [Required(ErrorMessage = "El campo IdSupervisor es requerido")]
        public int IdSupervisor { get; set; }
        [JsonProperty("Plato")]
        [Required(ErrorMessage = "El campo Plato es requerido")]
        [StringLength(25)]
        public string Plato { get; set; }
        [JsonProperty("Valor")]
        [Required(ErrorMessage = "El campo Valor es requerido")]
        public decimal Valor { get; set; }
    }
    public class Detalle_x_FacturaOutputDTO
    {
        public Detalle_x_FacturaOutputDTO()
        {
            Supervisor = new SupervisorOutputDTO();
            Factura = new FacturaDTO();
        }
        [JsonProperty("IdDetallexFactura")]
        public int? IdDetallexFactura { get; set; }
        [JsonProperty("NroFactura")]
        public int NroFactura { get; set; }
        [JsonProperty("IdSupervisor")]
        public int IdSupervisor { get; set; }
        [JsonProperty("Plato")]
        public string Plato { get; set; }
        [JsonProperty("Valor")]
        public decimal Valor { get; set; }
        public SupervisorOutputDTO Supervisor { get; set; }
        public FacturaDTO Factura { get; set; }
    }
}
