using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Aplication.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IEcommerceContext _ecommerceContext;
        private readonly IMapper _mapper;

        public UsuarioService(IEcommerceContext ecommerceContext, IMapper mapper)
        {
            _ecommerceContext = ecommerceContext;
            _mapper = mapper;
        }

        public bool Login(UsuarioParametroDto usuarioParametroDto)
        {
            bool existeUsuario = _ecommerceContext.Usuarios
                .Any(u => u.Email == usuarioParametroDto.Email && u.Clave == usuarioParametroDto.Clave);
                                    
            //bool resultado = usuario != null ? true : false; //Operaciòn ternaria
            return existeUsuario;
        }

        public EmpleadoDto LoginInfo(UsuarioParametroDto usuarioParametroDto)
        {
            Usuario usuario = _ecommerceContext.Usuarios
                            .Include(u => u.Empleado)
                            .FirstOrDefault(u => u.Email == usuarioParametroDto.Email && u.Clave == usuarioParametroDto.Clave);
            if (usuario == null)
                return null;

            EmpleadoDto empleadoDto = _mapper.Map<EmpleadoDto>(usuario.Empleado);
            return empleadoDto;
        }

        public int Crear(UsuarioParametroDto usuarioParametroDto)
        {
            bool existeEmail =  _ecommerceContext.Usuarios 
                .Any(u => u.Email == usuarioParametroDto.Email);
            if (existeEmail == true)
            {
                throw new Exception("El Correo ya existe");
            }

            bool existeUsuarioIdEmpleado = _ecommerceContext.Usuarios
                //any sirve para verificar si existe o no == tru o false
                    .Any(u => u.IdEmpleado  == usuarioParametroDto.IdEmpleado);
            if (existeUsuarioIdEmpleado == true)
            {
                throw new Exception("El empleado ya tiene un usuario");
            }

            Usuario usuario = new Usuario
            {
                Email = usuarioParametroDto.Email,
                Clave = usuarioParametroDto.Clave,
                IdEmpleado = usuarioParametroDto.IdEmpleado
            };

            _ecommerceContext.Usuarios.Add(usuario);
            _ecommerceContext.SaveChanges();
            return usuario.Id;
        }

        public void Eliminar(int id)
        {
            Usuario usuario = _ecommerceContext.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                throw new Exception($"No existe el Usuario con el ID: {id}");
            }

            _ecommerceContext.Usuarios.Remove(usuario);
            _ecommerceContext.SaveChanges();
        }

        public void Modificar(UsuarioParametroDto usuarioParametroDto)
        {
            Usuario usuario = _ecommerceContext.Usuarios.FirstOrDefault(u => u.Id == usuarioParametroDto.Id);
            if (usuario == null)
            {
                throw new Exception($"NO existe el Usuario con este ID: {usuarioParametroDto.Id}");
            }
            usuario.Email = usuarioParametroDto.Email;
            usuario.Clave = usuarioParametroDto.Clave;
            usuario.IdEmpleado = usuarioParametroDto.IdEmpleado;

            _ecommerceContext.SaveChanges();
        }

        public UsuarioDto ObtenerPorId(int id)
        {
            Usuario usuario = _ecommerceContext.Usuarios
                .Include(u => u.Empleado)
                .FirstOrDefault(u => u.Id == id);
            UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return usuarioDto;
        }

        public List<UsuarioDto> ObtenerTodo()
        {
            List<Usuario> usuarios = _ecommerceContext.Usuarios
                .Include(e => e.Empleado)
                .ToList();
            List<UsuarioDto> usuarioDto = _mapper.Map<List<UsuarioDto>>(usuarios);
            return usuarioDto;
        }

    }
}

