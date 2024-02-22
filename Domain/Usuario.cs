namespace Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

        //Parametros para trabajar la fk
        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }

        public Usuario() { }
    }
}
