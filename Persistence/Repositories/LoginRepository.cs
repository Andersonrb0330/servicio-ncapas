using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class LoginRepository : ILoginRepository
	{
		private readonly EcommerceContext _ecommerceContext;

		public LoginRepository(
			EcommerceContext ecommerceContext)
		{
			_ecommerceContext = ecommerceContext;
		}

        public async Task<Usuario> Login(string email, string clave)
        {
            Usuario usuarioinfo = await _ecommerceContext.Usuarios
                .Include(u => u.Empleado)
                .FirstOrDefaultAsync(u => u.Email == email && u.Clave == clave);
            return usuarioinfo;
        }
    }
}

