using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IValidator<EmpresaParametroDto> _validarEmpresa;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpresaService(
            IEmpresaRepository empresaRepository,
            IValidator<EmpresaParametroDto> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _validarEmpresa = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task< List<EmpresaDto>> ObtenerTodo()
        {
            List<Empresa> empresa = await _empresaRepository.Get();
            List<EmpresaDto> empresaDtos = _mapper.Map<List<EmpresaDto>>(empresa);
            return empresaDtos;
        }

        public async Task<EmpresaDto> ObtenerPorId(int id)
        {
            Empresa empresa = await _empresaRepository.GetById(id);
            EmpresaDto empresaDto = _mapper.Map<EmpresaDto>(empresa);
            return empresaDto;
        }

        public async Task<int> Crear(EmpresaParametroDto empresaParametroDto)
        {
            var validationResult = _validarEmpresa.Validate(empresaParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Empresa empresa = new Empresa
            {
                Nombre = empresaParametroDto.Nombre
            };
            await _empresaRepository.Create(empresa);
            await _unitOfWork.SaveChangesAsync();
            return empresa.Id;
        }


        public async void Modificar(EmpresaParametroDto empresaParametroDto)
        {
            Empresa empresa = await _empresaRepository.GetById(empresaParametroDto.Id);
            if (empresa == null) {
                throw new Exception($"NO existe empresa con ese ID {empresaParametroDto.Id}");
            }
            empresa.Nombre = empresaParametroDto.Nombre;
            await _unitOfWork.SaveChangesAsync();

        }

        public async void Eliminar(int id)
        {
            Empresa empresa = await _empresaRepository.GetById(id);
            if (empresa == null)
            {
                throw new Exception($"NO existe empresa con ese ID {id}");
            }
            _empresaRepository.Delete(empresa);
            await _unitOfWork.SaveChangesAsync();
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

