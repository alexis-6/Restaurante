using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.BL.Models
{
    [Table("Detalle_x_Factura", Schema = "dbo")]
    public class Detalle_x_Factura
    {
        [Key]
        public int? IdDetallexFactura { get; set; } = null;
        [ForeignKey("Factura")]
        public int NroFactura { get; set; }
        [ForeignKey("Supervisor")]
        public int IdSupervisor { get; set; }
        public string Plato { get; set; }
        public decimal Valor { get; set; }
        public virtual Supervisor Supervisor { get; set; }
        public virtual Factura Factura { get; set; }
    }
}