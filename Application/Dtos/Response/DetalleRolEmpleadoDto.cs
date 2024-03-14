using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class DetalleRolEmpleadoDto
	{
		public int Id { get; set; }

		public RolDto RolDto { get; set; }
		public EmpleadoDto EmpleadoDto { get; set; }

		public DetalleRolEmpleadoDto()
		{
		}
	}

    public class DetalleRolEmpleadoProfile : Profile
    {
        public DetalleRolEmpleadoProfile()
        {
            CreateMap<DetalleRolEmpleado, DetalleRolEmpleadoDto>();
        }
    }
}

