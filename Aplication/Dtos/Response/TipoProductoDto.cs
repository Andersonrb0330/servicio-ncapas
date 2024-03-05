using AutoMapper;
using Domain.Entity;

namespace Aplication.Dtos.Response
{
    public class TipoProductoDto
	{
		public int Id { get; set; }
        public string Nombre { get; set; }

        public TipoProductoDto()
		{
		}
     
    }

    public class TipoProductoProfile : Profile
    {
        public TipoProductoProfile()
        {
            CreateMap<TipoProducto, TipoProductoDto>();
        }
    }
}

