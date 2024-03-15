using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IEcommerceContext _ecommerceContext;

        public UsuarioRepository(IEcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public async Task<Usuario> LoginInfo(string email, string clave)
        {
            Usuario usuarioinfo = await _ecommerceContext.Usuarios
                .Include(u => u.Empleado)
                .ThenInclude(e => e.DetalleRolEmpleado)
                .ThenInclude(d => d.Rol)
                .FirstOrDefaultAsync(u => u.Email == email && u.Clave == clave);
            return usuarioinfo;
        }

        public async Task<List<Usuario>> Get()
        {
            List<Usuario> usuarios = await _ecommerceContext.Usuarios
                .Include(e => e.Empleado)
                .ToListAsync();
            return usuarios;
        }

        public async Task<Usuario> GetById(int id)
        {
            Usuario usuario = await _ecommerceContext.Usuarios
               .Include(u => u.Empleado)
               .FirstOrDefaultAsync(u => u.Id == id);
            return usuario;
        }

        public async Task Create(Usuario usuario)
        {
            await _ecommerceContext.Usuarios.AddAsync(usuario);
        }

        public async Task<bool> VerificarEmail(string email)
        {
            bool existeEmail = await _ecommerceContext.Usuarios
                 .AnyAsync(u => u.Email == email);
            return existeEmail;
        }

        public async Task<bool> VerificarEmpleadoUsuario(int idEmpleado)
        {
            bool existeUsuarioIdEmpleado = await _ecommerceContext.Usuarios
                    .AnyAsync(u => u.IdEmpleado == idEmpleado);
            return existeUsuarioIdEmpleado;
        }

        public async Task<bool> VerificarUsuario(int id)
        {
            bool existeUsuario = await _ecommerceContext.Usuarios
                     .AnyAsync(u => u.Id == id);
            return existeUsuario;
        }

        public void Delete(Usuario usuario)
        {
            _ecommerceContext.Usuarios.Remove(usuario);
            _ecommerceContext.SaveChanges();            
        }

        public async Task<List<Usuario>> GetPaginado(IQueryable<Usuario> queryable, int limite, int excluir)
        {
            return queryable
                    .OrderBy(p => p.Id)
                    .Skip(excluir)
                    .Take(limite)
                    .ToList();
        }

        public async Task<IQueryable<Usuario>> GetQueryable()
        {
            IQueryable<Usuario> usuario = _ecommerceContext.Usuarios
                .Include(u => u.Empleado)
                .AsQueryable();
            return usuario;
        }
    }
}

