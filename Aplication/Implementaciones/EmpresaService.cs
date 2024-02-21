using Aplication.Dtos.Response;
using Aplication.Dtos.Request;
using Aplication.Interfaces;
using AutoMapper;
using Domain;
using Persistence.Context;

namespace Aplication.Implementaciones
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEcommerceContext _ecommerceContext;
        private readonly IMapper _mapper;

        public EmpresaService(IEcommerceContext ecommerceContext, IMapper mapper)
        {
            _ecommerceContext = ecommerceContext;
            _mapper = mapper;
        }

        public int Crear(EmpresaParametroDto empresaParametroDto)
        {
            Empresa empresa = new Empresa
            {
                Nombre = empresaParametroDto.Nombre
            };

            _ecommerceContext.Empresas.Add(empresa);
            _ecommerceContext.SaveChanges();
            return empresa.Id;
        }

        public void Eliminar(int id)  
        {
            Empresa empresa = _ecommerceContext.Empresas.FirstOrDefault(e => e.Id == id);
            if (empresa == null)
            {
                throw new Exception($"NO existe empresa con ese ID {id}");
            }

            _ecommerceContext.Empresas.Remove(empresa);
            _ecommerceContext.SaveChanges();   
        }

        public void Modificar(EmpresaParametroDto empresaParametroDto)
        {
            Empresa empresa = _ecommerceContext.Empresas.FirstOrDefault(e => e.Id == empresaParametroDto.Id);
            if (empresa == null) {
                throw new Exception($"NO existe empresa con ese ID {empresaParametroDto.Id}");
            }

            empresa.Nombre = empresaParametroDto.Nombre;
            _ecommerceContext.SaveChanges();
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

