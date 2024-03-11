using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Response
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
            CreateMap<Empresa, EmpresaDto>();
        }
    }
}

