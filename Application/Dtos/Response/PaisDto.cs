using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class PaisDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }

		public PaisDto()
		{
		}
	}
    public class PaisProfile : Profile
    {
        public PaisProfile()
        {
            CreateMap<Pais, PaisDto>();
        }
    }
}

