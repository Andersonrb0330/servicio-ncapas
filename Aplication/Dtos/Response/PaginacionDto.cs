namespace Aplication.Dtos.Response
{
    public class PaginacionDto<T>
	{
		public int TotalItems { get; set; }
		public int PaginaActual { get; set; }
		public int TotalPaginas { get; set; }
        public List<T> Items { get; set; } 
        public PaginacionDto()
		{
		}
	}
}

