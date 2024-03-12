namespace Shared.Models.Reqres
{
    public class UsuarioModel
	{
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Avatar { get; set; }

        public UsuarioModel()
	    {
		}
	}
}

