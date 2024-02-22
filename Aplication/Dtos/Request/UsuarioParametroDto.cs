using System;
namespace Aplication.Dtos.Request
{
	public class UsuarioParametroDto
	{
        public int Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

		public int IdEmpleado { get; set; }

        public UsuarioParametroDto()
		{
		}
	}
}

