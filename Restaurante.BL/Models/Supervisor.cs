using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.BL.Models
{
    [Table("Supervisor", Schema = "dbo")]
    public class Supervisor
    {
        [Key]
        public int? IdSupervisor { get; set; } = null;
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public int Antiguedad_x_Anio { get; set; }
        public virtual ICollection<Detalle_x_Factura> Detalle_x_Factura { get; set; }
    }
}