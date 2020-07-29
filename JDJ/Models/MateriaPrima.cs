namespace JDJ.Models
{
    public class MateriaPrima
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; }
        public TipoProducto TipoProducto { get; set; }
    }
}