namespace Aplication.Dtos.Request
{
    public class FiltroEmpleadoParametroDto : PaginacionParametroDto
	{
		public string Nombre  { get; set; }
		public string Apellido { get; set; }
		public int? Edad { get; set; }

		public FiltroEmpleadoParametroDto()
		{
		}
	}
}

