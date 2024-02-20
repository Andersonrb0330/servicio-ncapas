using AutoMapper;
using Domain;

namespace Aplication.Dtos
{
    public class EmpresaDto
	{
        public int Id { get; set; }
        public string Nombre { get; set; }

        public EmpresaDto()
		{
		}
	}


    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<TipoProducto, TipoProductoDto>();
        }
    }
}

