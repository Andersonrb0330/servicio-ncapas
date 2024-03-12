using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class EmpleadoService : IEmpleadoService
	{
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IValidator<EmpleadoParametroDto> _validarEmpleado;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

		public EmpleadoService(  
            IEmpleadoRepository empleadoRepository,
            IEmpresaRepository empresaRepository,
            IValidator<EmpleadoParametroDto> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
		{       
            _empresaRepository = empresaRepository;
            _empleadoRepository = empleadoRepository;
            _validarEmpleado = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
		} 

        public async Task<List<EmpleadoDto>> Get()
        {
            List<Empleado> empleados = await _empleadoRepository.Get();
            List<EmpleadoDto> empleadoDto = _mapper.Map<List<EmpleadoDto>>(empleados);
            return empleadoDto;
        }

        public async Task<EmpleadoDto> GetById(int id)
        {
            Empleado empleado = await _empleadoRepository.GetById(id);
            EmpleadoDto empleadoDto = _mapper.Map<EmpleadoDto>(empleado);
            return empleadoDto;
        }

        public async Task<int> Create(EmpleadoParametroDto empleadoParametroDto)
        {
            var validationResult = _validarEmpleado.Validate(empleadoParametroDto);
            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            bool existeEmpresa = await _empresaRepository.VerificarEmpresa(empleadoParametroDto.IdEmpresa);
            if (!existeEmpresa)
            {
                throw new Exception($"El ID :{empleadoParametroDto.IdEmpresa} de la empresa  no existe");
            }                  
            Empleado empleado = new Empleado
            {
                Nombre   = empleadoParametroDto.Nombre,
                Apellido = empleadoParametroDto.Apellido,
                Edad = empleadoParametroDto.Edad,
                Dni  = empleadoParametroDto.Dni,
                Telefono = empleadoParametroDto.Telefono,
                IdEmpresa = empleadoParametroDto.IdEmpresa                
            };

            await _empleadoRepository.Create(empleado);
            await _unitOfWork.SaveChangesAsync();
            return empleado.Id;
        }

        public async void Update(EmpleadoParametroDto empleadoParametroDto)
        {
            Empleado empleado = await _empleadoRepository.GetById(empleadoParametroDto.Id);
            if (empleado == null)
            {
                throw new Exception($"No existe el empleado con este ID: {empleadoParametroDto.Id}");
            }

            bool existeEmpresa = await _empresaRepository.VerificarEmpresa(empleadoParametroDto.IdEmpresa);
            if (existeEmpresa == false)
            {
                throw new Exception($"El ID :{empleadoParametroDto.IdEmpresa} de la empresa  no existe");
            }

            empleado.Nombre = empleadoParametroDto.Nombre;
            empleado.Apellido = empleadoParametroDto.Apellido;     
            empleado.Dni = empleadoParametroDto.Dni;
            empleado.Edad = empleadoParametroDto.Edad;
            empleado.Telefono = empleadoParametroDto.Telefono;
            empleado.IdEmpresa = empleadoParametroDto.IdEmpresa;

            await _unitOfWork.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            Empleado empleado = await _empleadoRepository.GetById(id);
            if (empleado == null)
            {
                throw new Exception($"No existe el empleado con este ID: {id}");
            };

            _empleadoRepository.Delete(empleado);
            await _unitOfWork.SaveChangesAsync();
        }

        public PaginacionDto<EmpleadoDto> ObtenerEmpleadoPaginado(FiltroEmpleadoParametroDto filtroEmpleadoParametroDto)
        {
            IQueryable<Empleado> consulta = _empleadoRepository.GetQueryable();
            if (!string.IsNullOrWhiteSpace(filtroEmpleadoParametroDto.Nombre))
            {
                consulta = consulta.Where(e => e.Nombre.Contains(filtroEmpleadoParametroDto.Nombre));
            }
            if (!string.IsNullOrWhiteSpace(filtroEmpleadoParametroDto.Apellido))
            {
                consulta = consulta.Where(e => e.Apellido.Contains(filtroEmpleadoParametroDto.Apellido));
            }
            if (filtroEmpleadoParametroDto.Edad.HasValue)
            {
                consulta = consulta.Where(p => p.Edad == filtroEmpleadoParametroDto.Edad);
            }

            int totalEmpleados = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalEmpleados / filtroEmpleadoParametroDto.Limite);
            var excluirElementos = filtroEmpleadoParametroDto.Limite * filtroEmpleadoParametroDto.Pagina;
            var empleadoPaginados = _empleadoRepository.GetPaginado(consulta, filtroEmpleadoParametroDto.Limite, excluirElementos);
            var empleadoDto = _mapper.Map<List<EmpleadoDto>>(empleadoPaginados);
            var paginacionDto = new PaginacionDto<EmpleadoDto>
            {
                TotalItems = totalEmpleados,
                PaginaActual = filtroEmpleadoParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = empleadoDto
            };
            return paginacionDto;
        }
    }
}

