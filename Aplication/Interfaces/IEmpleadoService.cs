using System;
using Aplication.Dtos.Request;
using Aplication.Dtos.Response;

namespace Aplication.Interfaces
{
	public interface IEmpleadoService
	{
		List<EmpleadoDto> Get();

		EmpleadoDto GetById(int id);

        int Create(EmpleadoParametroDto empleadoParametroDto);

		void Update(EmpleadoParametroDto empleadoParametroDto);

		void Delete(int id);
	}
}

