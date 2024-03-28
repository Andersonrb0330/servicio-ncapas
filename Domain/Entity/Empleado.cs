namespace Domain.Entity
{
    public class Empleado
	{
		public int Id { get; set; }
		public string Nombre{ get; set; }
		public string Apellido { get; set; }
		public  int Edad{ get; set; }
		public string  Dni { get; set; }
		public string Telefono { get; set; }

		//Parametros para trabajar la fk
		public int IdEmpresa { get; set; }
		public virtual Empresa Empresa { get; set; }


		public ICollection<DetalleRolEmpleado> DetalleRolEmpleado { get; set; }

        public Empleado()
		{
		}
	}
}

