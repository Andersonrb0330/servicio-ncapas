namespace Domain
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Empleado> Empleados { get; set; }

        public Empresa() { }
    }

}
