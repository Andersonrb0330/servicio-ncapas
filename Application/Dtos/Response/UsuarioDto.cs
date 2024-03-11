using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
{
    public class UsuarioDto
	{
        public int Id { get; set; }
        public string Email { get; set; }
        //public string Clave { get; set; }

        public EmpleadoDto Empleado { get; set; }

        public UsuarioDto()
		{
		}     
    }

    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}

