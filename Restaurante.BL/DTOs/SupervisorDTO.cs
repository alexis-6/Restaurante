using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.BL.DTOs
{
    public class SupervisorDTO
    {
        [JsonProperty("IdSupervisor")]
        public int? IdSupervisor { get; set; }
        [JsonProperty("Nombres")]
        [Required(ErrorMessage = "El campo Nombres es requerido")]
        [StringLength(25)]
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
    public class SupervisorOutputDTO
    {
        [JsonProperty("IdSupervisor")]
        public int? IdSupervisor { get; set; }
        [JsonProperty("Nombres")]
        public string Nombres { get; set; }
        [JsonProperty("Apellidos")]
        public string Apellidos { get; set; }
        [JsonProperty("Edad")]
        public int Edad { get; set; }
        [JsonProperty("Antiguedad_x_Anio")]
        public int Antiguedad_x_Anio { get; set; }
    }
}
