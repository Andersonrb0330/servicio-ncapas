using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain;
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

        public int Crear(UsuarioParametroDto usuarioParametroDto)
        {
            Usuario usuario = new Usuario
            {
                Nombre = usuarioParametroDto.Nombre,
                Apellido = usuarioParametroDto.Apellido,
                Edad = usuarioParametroDto.Edad,
                Telefono = usuarioParametroDto.Telefono,
                FechaNacimiento = usuarioParametroDto.FechaNacimiento,
                Email = usuarioParametroDto.Email,
                Clave = usuarioParametroDto.Clave
            };

            _ecommerceContext.Usuarios.Add(usuario);
            _ecommerceContext.SaveChanges();
            return usuario.Id;
        }

        public void Eliminar(int id)
        {
            Usuario usuario = _ecommerceContext.Usuarios.FirstOrDefault(u => u.Id  == id);
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

            usuario.Nombre = usuarioParametroDto.Nombre;
            usuario.Apellido = usuarioParametroDto.Apellido;
            usuario.Edad = usuarioParametroDto.Edad;
            usuario.Telefono = usuarioParametroDto.Telefono;
            usuario.FechaNacimiento = usuarioParametroDto.FechaNacimiento;
            usuario.Email = usuarioParametroDto.Email;
            usuario.Clave = usuarioParametroDto.Clave;

            _ecommerceContext.SaveChanges();
        }

        public UsuarioDto ObtenerPorId(int id)
        {
            Usuario usuario = _ecommerceContext.Usuarios.FirstOrDefault(u => u.Id == id);
            UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return usuarioDto;
        }

        public List<UsuarioDto> ObtenerTodo()
        {
            List<Usuario> usuarios = _ecommerceContext.Usuarios.ToList();
            List<UsuarioDto> usuarioDto = _mapper.Map<List<UsuarioDto>>(usuarios);
            return usuarioDto;
        }

     
    }
}

