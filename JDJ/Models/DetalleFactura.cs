using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JDJ.Models
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public DateTime FechaFactura { get; set; }
        public int Cantidad { get; set; }
        public Factura Factura { get; set; }
        public Producto Producto { get; set; }

    }
}
