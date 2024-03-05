namespace Domain.Entity
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }

        public int IdTipoProducto { get; set; }

        public virtual TipoProducto TipoProducto { get; set; }
        
        public Producto() { }

    }
}
