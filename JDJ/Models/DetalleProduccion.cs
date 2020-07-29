using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JDJ.Models
{
    public class DetalleProduccion
    {
        public int Id { get; set; }
        public int MateriaPrimaConsumida { get; set; }
        public int MargenGanancia { get; set; }
        public double Costo { get; set; }
        public Producto Producto { get; set; }
        public TipoPrenda TipoPrenda { get; set; }
        public MateriaPrima MateriaPrima { get; set; }
    }
}
