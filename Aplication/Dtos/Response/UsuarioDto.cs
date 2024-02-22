using AutoMapper;
using Domain;

namespace Aplication.Dtos.Response
{
    public class UsuarioDto
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

        public EmpleadoDto Empleado { get; set; }

        public UsuarioDto()
		{
		}
       
    }

    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Empleado, UsuarioDto>();
        }
    }
}

