using AutoMapper;
using Domain;

namespace Aplication.Dtos.Response
{
    public class ProductoDto
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }


        public ProductoDto()
		{
		}
	}
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<TipoProducto, TipoProductoDto>();
        }
    }


}

