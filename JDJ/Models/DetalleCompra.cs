using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JDJ.Models
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public MateriaPrima MateriaPrima { get; set; }
        public Compra Compra { get; set; }
    }
}
