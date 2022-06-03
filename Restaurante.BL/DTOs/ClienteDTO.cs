using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Restaurante.BL.DTOs
{
    public class ClienteDTO
    {
        [JsonProperty("Identificacion")]
        [Required(ErrorMessage = "El campo Identificacion es requerido")]
        [StringLength(10)]
        public string Identificacion { get; set; }
        [JsonProperty("Nombres")]
        [Required(ErrorMessage = "El campo Nombres es requerido")]
        [StringLength(20)]
        public string Nombres { get; set; }
        [JsonProperty("Apellidos")]
        [Required(ErrorMessage = "El campo Apellidos es requerido")]
        [StringLength(25)]
        public string Apellidos { get; set; }
        [JsonProperty("Direccion")]
        [Required(ErrorMessage = "El campo Direccion es requerido")]
        [StringLength(25)]
        public string Direccion { get; set; }
        [JsonProperty("Telefono")]
        [Required(ErrorMessage = "El campo Telefono es requerido")]
        [StringLength(10)]
        public string Telefono { get; set; }
    }
}