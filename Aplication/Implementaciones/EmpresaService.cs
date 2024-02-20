using Aplication.Dtos;
using Aplication.Interfaces;
using AutoMapper;
using Domain;
using Persistence.Context;

namespace Aplication.Implementaciones
{
    public class EmpresaService  : IEmpresaService
	{
        private readonly IEcommerceContext _ecommerceContext;
        private readonly IMapper _mapper;

        public EmpresaService(IEcommerceContext ecommerceContext,  IMapper mapper) {
            _ecommerceContext = ecommerceContext;
            _mapper = mapper;
        }

        public EmpresaDto ObtenerPorId(int id)
        {
            Empresa empresa = _ecommerceContext.Empresas.FirstOrDefault(e => e.Id == id);

            EmpresaDto empresaDto = _mapper.Map<EmpresaDto>(empresa);

            return empresaDto;

        }

        public List<EmpresaDto> ObtenerTodo()
        {
            List<Empresa> empresa = _ecommerceContext.Empresas.ToList();

            List<EmpresaDto> empresaDtos = _mapper.Map<List<EmpresaDto>>(empresa);

            return empresaDtos;
        }

 

    }
}

