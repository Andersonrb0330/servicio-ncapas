using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Description { get; set; }
        public bool Estado { get; set; }
        public string Stock { get; set; }
        public double Precio { get; set; }
        
        public Producto() { }

    }
}
