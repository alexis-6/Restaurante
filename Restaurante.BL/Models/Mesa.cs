using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.BL.Models
{
    [Table("Mesa", Schema = "dbo")]
    public class Mesa
    {
        [Key]
        public int? NroMesa { get; set; } = null;
        public string Nombre { get; set; }
        public bool Reservada { get; set; }
        public int Puestos { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}