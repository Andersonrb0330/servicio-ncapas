namespace Application.Dtos.Response
{
    public class SeguridadEmpleadoDto
	{
		public string Token { get; set; }
		public EmpleadoDto Empleado { get; set; }

		public SeguridadEmpleadoDto()
		{
		}
	}
}

