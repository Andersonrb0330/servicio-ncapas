namespace Application.Dtos.Request
{
    public class FiltroUsuarioParametroDto : PaginacionParametroDto
	{
		public string Email  { get; set; }
		public int? IdEmpleado  { get; set; }

		public FiltroUsuarioParametroDto()
		{
		}
	}
}

