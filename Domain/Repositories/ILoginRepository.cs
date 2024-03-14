using Domain.Entity;

namespace Domain.Repositories
{
    public interface ILoginRepository
	{
        Task<Usuario> Login(string email, string clave);
    }
}

