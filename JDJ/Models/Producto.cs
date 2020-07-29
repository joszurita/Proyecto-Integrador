using System;

namespace JDJ.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public DateTime FechaProduccion { get; set; }
        public int Cantidad { get; set; }
        public double PVP { get; set; }
    }
}