using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Aplication.Implementaciones
{
    public class EmpleadoService : IEmpleadoService
	{
        private readonly IEcommerceContext _ecommerceContext;
        private readonly IMapper _mapper;

		public EmpleadoService(IEcommerceContext ecommerceContext, IMapper mapper )
		{
            _ecommerceContext = ecommerceContext;
            _mapper = mapper;
		}

        public List<EmpleadoDto> Get()
        {
            List<Empleado> empleado = _ecommerceContext.Empleados
                .Include(e => e.Empresa)
                .ToList();
            List<EmpleadoDto> empleadoDto = _mapper.Map<List<EmpleadoDto>>(empleado);
            return empleadoDto;
        }

        public EmpleadoDto GetById(int id)
        {
            Empleado empleado = _ecommerceContext.Empleados
                .Include(e => e.Empresa)
                .FirstOrDefault(e => e.Id == id);
            EmpleadoDto empleadoDto = _mapper.Map<EmpleadoDto>(empleado);
            return empleadoDto;
        }

        public int Create(EmpleadoParametroDto empleadoParametroDto)
        {
            Empleado empleado = new Empleado
            {
                Nombre   = empleadoParametroDto.Nombre,
                Apellido = empleadoParametroDto.Apellido,
                Edad = empleadoParametroDto.Edad,
                Dni  = empleadoParametroDto.Dni,
                Telefono = empleadoParametroDto.Telefono,
                IdEmpresa = empleadoParametroDto.IdEmpresa                
            };

            _ecommerceContext.Empleados.Add(empleado);
            _ecommerceContext.SaveChanges();

            return empleado.Id;
        }

        public void Update(EmpleadoParametroDto empleadoParametroDto)
        {
            Empleado empleado = _ecommerceContext.Empleados.FirstOrDefault(e => e.Id ==  empleadoParametroDto.Id);
            if (empleado == null)
            {
                throw new Exception($"No existe el empleado con este ID: {empleadoParametroDto.Id}");
            }

            empleado.Nombre = empleadoParametroDto.Nombre;
            empleado.Apellido = empleadoParametroDto.Apellido;
            empleado.Dni = empleadoParametroDto.Dni;
            empleado.Edad = empleadoParametroDto.Edad;
            empleado.Telefono = empleadoParametroDto.Telefono;
            empleado.IdEmpresa = empleadoParametroDto.IdEmpresa;

            _ecommerceContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Empleado empleado = _ecommerceContext.Empleados.FirstOrDefault(e => e.Id == id);
            if (empleado == null)
            {
                throw new Exception($"No existe el empleado con este ID: {id}");
            };

            _ecommerceContext.Empleados.Remove(empleado);
            _ecommerceContext.SaveChanges();
        }
    }
}

