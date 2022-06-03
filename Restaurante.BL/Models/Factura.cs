using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.BL.Models
{
    [Table("Factura", Schema = "dbo")]
    public class Factura
    {
        //public Factura()
        //{
        //    Detalle_x_Factura = new HashSet<Detalle_x_Factura>();
        //}
        [Key]
        public int? NroFactura { get; set; } = null;
        [ForeignKey("Cliente")]
        public string IdCliente { get; set; }
        [ForeignKey("Mesa")]
        public int NroMesa { get; set; }
        [ForeignKey("Mesero")]
        public int IdMesero { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public virtual ICollection<Detalle_x_Factura> Detalle_x_Factura { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Mesa Mesa { get; set; }
        public virtual Mesero Mesero { get; set; }
    }
}