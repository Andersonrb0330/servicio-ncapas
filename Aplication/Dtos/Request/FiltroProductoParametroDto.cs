namespace Aplication.Dtos.Request
{
    public class FiltroProductoParametroDto : PaginacionParametroDto
    {
		public string Nombre { get; set; }
		public string Descripcion {get; set; }
		public bool? Estado { get; set; }

		public FiltroProductoParametroDto()
		{
		}
	}
}

