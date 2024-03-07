using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;

namespace Aplication.Implementaciones
{
    public class EmpleadoService : IEmpleadoService
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

		public EmpleadoService(
            IUnitOfWork unitOfWork,
            IEmpleadoRepository empleadoRepository,
            IEmpresaRepository empresaRepository,
            IMapper mapper)
		{
            _unitOfWork = unitOfWork;
            _empresaRepository = empresaRepository;
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
		}

        public List<EmpleadoDto> Get()
        {
            List<Empleado> empleados = _empleadoRepository.Get();
            List<EmpleadoDto> empleadoDto = _mapper.Map<List<EmpleadoDto>>(empleados);
            return empleadoDto;
        }

        public EmpleadoDto GetById(int id)
        {
            Empleado empleado = _empleadoRepository.GetById(id);
            EmpleadoDto empleadoDto = _mapper.Map<EmpleadoDto>(empleado);
            return empleadoDto;
        }

        public int Create(EmpleadoParametroDto empleadoParametroDto)
        {
            bool existeEmpresa = _empresaRepository.VerificarEmpresa(empleadoParametroDto.IdEmpresa);
            if (existeEmpresa == false)
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

            _empleadoRepository.Create(empleado);
            _unitOfWork.SaveChanges();
            return empleado.Id;
        }

        public void Update(EmpleadoParametroDto empleadoParametroDto)
        {
            Empleado empleado = _empleadoRepository.GetById(empleadoParametroDto.Id);
            if (empleado == null)
            {
                throw new Exception($"No existe el empleado con este ID: {empleadoParametroDto.Id}");
            }

            bool existeEmpresa = _empresaRepository.VerificarEmpresa(empleadoParametroDto.IdEmpresa);
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

            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            Empleado empleado = _empleadoRepository.GetById(id);
            if (empleado == null)
            {
                throw new Exception($"No existe el empleado con este ID: {id}");
            };

            _empleadoRepository.Delete(empleado);
            _unitOfWork.SaveChanges();
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

