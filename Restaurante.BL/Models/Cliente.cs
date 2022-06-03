using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.BL.Models
{
    [Table("Cliente", Schema = "dbo")]
    public class Cliente
    {
        [Key]
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}