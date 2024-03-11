namespace Application.Dtos.Request
{
    public class EmpleadoParametroDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public int IdEmpresa { get; set; }

        public EmpleadoParametroDto()
		{
		}
	}
}

