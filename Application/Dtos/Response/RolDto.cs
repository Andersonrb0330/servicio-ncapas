using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class RolDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public RolDto()
		{
		}
	}

    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<Rol, RolDto>();
        }
    }
}

