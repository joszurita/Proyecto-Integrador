namespace JDJ.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public float ValorTotal { get; set; }
        public Cliente Cliente { get; set; }
    }
}