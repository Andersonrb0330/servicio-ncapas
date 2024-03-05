using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
	{
        private readonly IEcommerceContext _ecommerceContext;

        public UsuarioRepository(IEcommerceContext ecommerceContext)
		{
			_ecommerceContext = ecommerceContext;
		}

        public List<Usuario> Get()
        {
            List<Usuario> usuarios = _ecommerceContext.Usuarios
                .Include(e => e.Empleado)
                .ToList();
            return usuarios;
        }
    }
}

