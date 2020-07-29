using Microsoft.EntityFrameworkCore;
using JDJ.Models;

namespace JDJ.Data
{
    public class PrincipalContext : DbContext
    {
        public PrincipalContext (DbContextOptions<PrincipalContext> options)
            : base(options)
        {
        }

        public DbSet<TipoPersona> TipoPersonas { get; set; }

        public DbSet <Cliente> Cliente { get; set; }

        public DbSet<Compra> Compras { get; set; }

        public DbSet<DetalleCompra> DetalleCompras { get; set; }

        public DbSet<DetalleFactura> DetalleFacturas { get; set; }

        public DbSet<DetalleProduccion> DetalleProducciones { get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public DbSet<MateriaPrima> MateriasPrimas { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<TipoPrenda> TipoPrendas { get; set; }

        public DbSet<TipoProducto> TipoProductos { get; set; }
    }
}
