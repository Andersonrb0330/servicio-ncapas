using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class DetalleRolEmpleadoService : IDetalleRolEmpleadoService
	{
        private readonly IDetalleRolEmpleadoRepository _detalleRolEmpleadoRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IValidator<DetalleRolEmpleadoParametroDto> _validarDetalleRolEmpleado;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

		public DetalleRolEmpleadoService(
            IDetalleRolEmpleadoRepository detalleRolEmpleadoRepository,
            IEmpleadoRepository empleadoRepository,
            IRolRepository rolRepository,
            IValidator<DetalleRolEmpleadoParametroDto> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
		{
            _detalleRolEmpleadoRepository = detalleRolEmpleadoRepository;
            _empleadoRepository = empleadoRepository;
            _rolRepository = rolRepository;
            _validarDetalleRolEmpleado = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
		}

        public async Task<List<DetalleRolEmpleadoDto>> Get()
        {
            List<DetalleRolEmpleado> detalleRolEmpleados = await _detalleRolEmpleadoRepository.Get();
            List<DetalleRolEmpleadoDto> detalleRolEmpleadoDtos = _mapper.Map<List<DetalleRolEmpleadoDto>>(detalleRolEmpleados);
            return detalleRolEmpleadoDtos;                
        }

        public async Task<DetalleRolEmpleadoDto> GetById(int id)
        {
            DetalleRolEmpleado detalleRolEmpleado = await _detalleRolEmpleadoRepository.GetById(id);
            DetalleRolEmpleadoDto detalleRolEmpleadoDto = _mapper.Map<DetalleRolEmpleadoDto>(detalleRolEmpleado);
            return detalleRolEmpleadoDto;
        }

        public async Task<int> Create(DetalleRolEmpleadoParametroDto detalleRolEmpleadoParametroDto)
        {
            var validationResult = _validarDetalleRolEmpleado.Validate(detalleRolEmpleadoParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            bool existeRol = await _rolRepository.ExisteRol(detalleRolEmpleadoParametroDto.IdRol);
            if (!existeRol)
            {
                throw new Exception("El Rol no existe");
            }

            Empleado empleado = await _empleadoRepository.GetEmpleadoConDetalleRolById(detalleRolEmpleadoParametroDto.IdEmpleado);
            if (empleado == null)
            {
                throw new Exception("El Empleado no existe");
            }

            bool existeEmpleadoRol = empleado.DetalleRolEmpleado.Any(e => e.IdRol == detalleRolEmpleadoParametroDto.IdRol);
            if (existeEmpleadoRol == true)
            {
                throw new Exception("El empleado ya tiene el rol seleccionado");
            }

            /*bool existeEmpleado = await _empleadoRepository.ExisteEmpleado(detalleRolEmpleadoParametroDto.IdEmpleado);
            if (!existeEmpleado)
            {
                throw new Exception("El Empleado no existe");
            }

            bool existeEmpleadoRol = await _detalleRolEmpleadoRepository.VerificarEmpleadoRol(
                detalleRolEmpleadoParametroDto.IdEmpleado,
                detalleRolEmpleadoParametroDto.IdRol);
            if (existeEmpleadoRol == true)
            {
                throw new Exception("El empleado ya tiene el rol seleccionado");
            }*/

            DetalleRolEmpleado detalleRolEmpleado = new DetalleRolEmpleado
            {
                IdRol = detalleRolEmpleadoParametroDto.IdRol,
                IdEmpleado = detalleRolEmpleadoParametroDto.IdEmpleado
            };

            await _detalleRolEmpleadoRepository.Create(detalleRolEmpleado);
            await _unitOfWork.SaveChangesAsync();
            return detalleRolEmpleado.Id;
        }

        public async Task Update(DetalleRolEmpleadoParametroDto detalleRolEmpleadoParametroDto)
        {
            DetalleRolEmpleado detalleRolEmpleado = await _detalleRolEmpleadoRepository.GetById(detalleRolEmpleadoParametroDto.Id);
            if(detalleRolEmpleado == null)
            {
                throw new Exception($"El Detalle Rol Empleado con el ID: {detalleRolEmpleado.Id} no existe");
            }

            bool existeRol = await _rolRepository.ExisteRol(detalleRolEmpleadoParametroDto.IdRol);
            if (!existeRol)
            {
                throw new Exception("El Rol no existe");
            }

            bool existeEmpleado = await _empleadoRepository.ExisteEmpleado(detalleRolEmpleadoParametroDto.IdEmpleado);
            if (!existeEmpleado)
            {
                throw new Exception("El Empleado no existe");
            }

            detalleRolEmpleado.IdRol = detalleRolEmpleadoParametroDto.IdRol;
            detalleRolEmpleado.IdEmpleado = detalleRolEmpleadoParametroDto.IdEmpleado;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            DetalleRolEmpleado detalleRolEmpleado = await _detalleRolEmpleadoRepository.GetById(id);
            if (detalleRolEmpleado == null)
            {
                throw new Exception($"El Detalle Rol Empleado con el ID: {id} no existe");
            }

            _detalleRolEmpleadoRepository.Delete(detalleRolEmpleado);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

