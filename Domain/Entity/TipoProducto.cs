﻿namespace Domain.Entity
{
    public class TipoProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public TipoProducto() { }
    }
}
