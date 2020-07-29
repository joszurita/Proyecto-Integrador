using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JDJ.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public double SubTotal { get; set; }
        public float IVA { get; set; }
        public double Total { get; set; }
        public Cliente Cliente { get; set; }
    }
}
