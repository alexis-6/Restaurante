using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.BL.Models
{
    [Table("Mesero", Schema = "dbo")]
    public class Mesero
    {
        [Key]
        public int? IdMesero { get; set; } = null;
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public int Antiguedad_x_Anio { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}