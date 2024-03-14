namespace Domain.Entity
{
    public class DetalleRolEmpleado
	{
		public int Id  { get; set; }

		public int IdRol { get; set; }
        public virtual Rol Rol { get; set; }
        
        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }	
	
		public DetalleRolEmpleado()
		{
		}
	}
}

