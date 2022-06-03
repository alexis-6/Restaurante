using Microsoft.EntityFrameworkCore;
using Restaurante.BL.Models;
using System.Configuration;

namespace Restaurante.BL.Data
{
    public class DataContext : DbContext
    {
        public string GetConection()
        {
            return ConfigurationManager.ConnectionStrings["Connection"].ToString();
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Mesero> Mesero { get; set; }
        public DbSet<Supervisor> Supervisor { get; set; }
        public DbSet<Detalle_x_Factura> Detalle_x_Factura { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
    }
}
