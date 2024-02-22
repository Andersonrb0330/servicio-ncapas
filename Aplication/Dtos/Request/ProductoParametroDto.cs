using System;
namespace Aplication.Dtos.Request
{
	public class ProductoParametroDto
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }

        public int IdTipoProducto { get; set; }

        public ProductoParametroDto()
		{
		}
	}
}

