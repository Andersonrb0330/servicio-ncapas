using Domain.Entity;

namespace Domain.Repositories
{
    public interface IUsuarioRepository
	{
        List<Usuario> Get();
        Usuario GetById(int id);
        void Delete(Usuario usuario);
        void Create(Usuario usuario);
        bool VerificarEmail(string email);
        bool VerificarEmpleadoUsuario(int idEmpleado);
        bool Login(string email, string clave);
        Usuario LoginInfo(string email, string clave);
    }
}

