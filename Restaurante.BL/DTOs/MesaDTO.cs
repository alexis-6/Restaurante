using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.BL.DTOs
{
    public class MesaDTO
    {
        [JsonProperty("NroMesa")]
        public int? NroMesa { get; set; }
        [JsonProperty("Nombre")]
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(20)]
        public string Nombre { get; set; }
        [JsonProperty("Reservada")]
        [Required(ErrorMessage = "El campo Reservada es requerido")]
        public bool Reservada { get; set; }
        [JsonProperty("Puestos")]
        [Required(ErrorMessage = "El campo Puestos es requerido")]
        public int Puestos { get; set; }
    }
}
