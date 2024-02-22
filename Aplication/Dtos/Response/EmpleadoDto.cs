using AutoMapper;
using Domain;

namespace Aplication.Dtos.Response
{
    public class EmpleadoDto
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public EmpresaDto Empresa { get; set; }

        public EmpleadoDto()
		{
		}
	}

    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile()
        {
            CreateMap<Empleado, EmpleadoDto>();
        }
    }
}

