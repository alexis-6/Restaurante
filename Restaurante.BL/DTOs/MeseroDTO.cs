using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Restaurante.BL.DTOs
{
    public class MeseroDTO
    {
        [JsonProperty("IdMesero")]
        [Required(ErrorMessage = "El campo IdMesero es requerido")]
        public int? IdMesero { get; set; }
        [JsonProperty("Nombres")]
        [Required(ErrorMessage = "El campo Nombres es requerido")]
        [StringLength(20)]
        public string Nombres { get; set; }
        [JsonProperty("Apellidos")]
        [Required(ErrorMessage = "El campo Apellidos es requerido")]
        [StringLength(25)]
        public string Apellidos { get; set; }
        [JsonProperty("Edad")]
        [Required(ErrorMessage = "El campo Edad es requerido")]
        public int Edad { get; set; }
        [JsonProperty("Antiguedad_x_Anio")]
        [Required(ErrorMessage = "El campo Antiguedad_x_Anio es requerido")]
        public int Antiguedad_x_Anio { get; set; }
    }
}
