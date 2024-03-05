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

        public bool Login(string email, string clave)
        {
            bool existeUsuario = _ecommerceContext.Usuarios
                 //Any te devuelve un bool, true or false, 
                 .Any(u => u.Email == email && u.Clave == clave);
            return existeUsuario;
        }

        public Usuario LoginInfo(string email, string clave)
        {
            Usuario usuarioinfo = _ecommerceContext.Usuarios
                .Include(u => u.Empleado)
                .FirstOrDefault(u => u.Email == email && u.Clave == clave);
            return usuarioinfo;
        }

        public List<Usuario> Get()
        {
            List<Usuario> usuarios = _ecommerceContext.Usuarios
                .Include(e => e.Empleado)
                .ToList();
            return usuarios;
        }

        public Usuario GetById(int id)
        {
            Usuario usuario = _ecommerceContext.Usuarios
               .Include(u => u.Empleado)
               .FirstOrDefault(u => u.Id == id);
            return usuario;
        }

        public void Create(Usuario usuario)
        {
            _ecommerceContext.Usuarios.Add(usuario);
        }

        public bool VerificarEmail(string email)
        {
            bool existeEmail = _ecommerceContext.Usuarios
                 .Any(u => u.Email == email);
            return existeEmail;
        }

        public bool VerificarEmpleadoUsuario(int idEmpleado)
        {
            bool existeUsuarioIdEmpleado = _ecommerceContext.Usuarios
                    .Any(u => u.IdEmpleado == idEmpleado);
            return existeUsuarioIdEmpleado;
        }

        public void Delete(Usuario usuario)
        {
            _ecommerceContext.Usuarios.Remove(usuario);
            _ecommerceContext.SaveChanges();            
        }

        public bool VerificarUsuario(int id)
        {
           bool existeUsuario = _ecommerceContext.Usuarios
                    .Any(u => u.Id == id);
           return existeUsuario;
        }
    }
}

