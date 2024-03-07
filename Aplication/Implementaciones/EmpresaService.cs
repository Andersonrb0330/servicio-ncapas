using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;

namespace Aplication.Implementaciones
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaService(
            IEmpresaRepository empresaRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<EmpresaDto> ObtenerTodo()
        {
            List<Empresa> empresa = _empresaRepository.Get();
            List<EmpresaDto> empresaDtos = _mapper.Map<List<EmpresaDto>>(empresa);
            return empresaDtos;
        }

        public EmpresaDto ObtenerPorId(int id)
        {
            Empresa empresa = _empresaRepository.GetById(id);
            EmpresaDto empresaDto = _mapper.Map<EmpresaDto>(empresa);
            return empresaDto;
        }

        public int Crear(EmpresaParametroDto empresaParametroDto)
        {
            Empresa empresa = new Empresa
            {
                Nombre = empresaParametroDto.Nombre
            };
            _empresaRepository.Create(empresa);
            _unitOfWork.SaveChanges();
            return empresa.Id;
        }


        public void Modificar(EmpresaParametroDto empresaParametroDto)
        {
            Empresa empresa = _empresaRepository.GetById(empresaParametroDto.Id);
            if (empresa == null) {
                throw new Exception($"NO existe empresa con ese ID {empresaParametroDto.Id}");
            }
            empresa.Nombre = empresaParametroDto.Nombre;
            _unitOfWork.SaveChanges();
           
        }

        public void Eliminar(int id)
        {
            Empresa empresa = _empresaRepository.GetById(id);
            if (empresa == null)
            {
                throw new Exception($"NO existe empresa con ese ID {id}");
            }
            _empresaRepository.Delete(empresa);
            _unitOfWork.SaveChanges();
        }

        public PaginacionDto<EmpresaDto> ObtenerEmpresaPaginado(FiltroEmpresaParametroDto filtroEmpresaParametroDto)
        {
            IQueryable<Empresa> consulta = _empresaRepository.GetQueryable();
            if (!string.IsNullOrWhiteSpace(filtroEmpresaParametroDto.Nombre))
            {
                consulta = consulta.Where(e => e.Nombre.Contains(filtroEmpresaParametroDto.Nombre));
            }

            int totalEmpresas = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalEmpresas / filtroEmpresaParametroDto.Limite);
            var excluirElementos = filtroEmpresaParametroDto.Limite * filtroEmpresaParametroDto.Pagina;
            var empresaPaginados = _empresaRepository.GetPaginado(consulta, filtroEmpresaParametroDto.Limite, excluirElementos);
            var empresaDto = _mapper.Map<List<EmpresaDto>>(empresaPaginados);
            var paginacionDto = new PaginacionDto<EmpresaDto>
            {
                TotalItems = totalEmpresas,
                PaginaActual = filtroEmpresaParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = empresaDto
            };
            return paginacionDto;
        }
    }
}

