namespace Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; } 
        public int Edad { get; set; }
        public string  Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

        public Usuario() { }
    }
}
