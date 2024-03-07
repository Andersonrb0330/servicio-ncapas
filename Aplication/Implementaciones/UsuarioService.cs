using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;


namespace Aplication.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,        
            IEmpleadoRepository  empleadoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _empleadoRepository = empleadoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<UsuarioDto> ObtenerTodo()
        {
            List<Usuario> usuarios = _usuarioRepository.Get();
            List<UsuarioDto> usuarioDto = _mapper.Map<List<UsuarioDto>>(usuarios);
            return usuarioDto;
        }

        public UsuarioDto ObtenerPorId(int id)
        {
            Usuario usuario = _usuarioRepository.GetById(id);
            UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return usuarioDto;
        }

        public int Crear(UsuarioParametroDto usuarioParametroDto)
        {
            bool existeEmail = _usuarioRepository.VerificarEmail(usuarioParametroDto.Email);
            if (existeEmail == true)
            {
                throw new Exception("El Correo ya existe");
            }

            bool existeUsuarioEmpleado = _usuarioRepository.VerificarEmpleadoUsuario(usuarioParametroDto.IdEmpleado);
            if (existeUsuarioEmpleado == true)
            {
                throw new Exception("El empleado ya tiene un usuario");
            }

            bool existeEmpleado = _empleadoRepository.ExisteEmpleado(usuarioParametroDto.IdEmpleado);
            if (existeEmpleado == false)
            {
                throw new Exception("El emplado no existe");
            }

            Usuario usuario = new Usuario
            {
                Email = usuarioParametroDto.Email,
                Clave = usuarioParametroDto.Clave,
                IdEmpleado = usuarioParametroDto.IdEmpleado
            };

            _usuarioRepository.Create(usuario);
            _unitOfWork.SaveChanges();
            return usuario.Id;
        }

        public void Modificar(UsuarioParametroDto usuarioParametroDto)
        {
            Usuario usuario = _usuarioRepository.GetById(usuarioParametroDto.Id);
            if (usuario == null)
            {
                throw new Exception($"NO existe el Usuario con este ID: {usuarioParametroDto.Id}");
            }
            usuario.Email = usuarioParametroDto.Email;
            usuario.Clave = usuarioParametroDto.Clave;
            usuario.IdEmpleado = usuarioParametroDto.IdEmpleado;

            _unitOfWork.SaveChanges();
        }

        public void Eliminar(int id)
        {
            Usuario usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                throw new Exception($"No existe el Usuario con el ID: {id}");
            }
            _usuarioRepository.Delete(usuario);
            _unitOfWork.SaveChanges();
        }

        public bool Login(UsuarioParametroDto usuarioParametroDto)
        {
            bool existeUsuario = _usuarioRepository.Login(usuarioParametroDto.Email, usuarioParametroDto.Clave);                                   
            //bool resultado = usuario != null ? true : false; //Operaciòn ternaria
            return existeUsuario;
        }

        public EmpleadoDto LoginInfo(UsuarioParametroDto usuarioParametroDto)
        {
            Usuario usuarioinfo = _usuarioRepository.LoginInfo(usuarioParametroDto.Email,
                                                               usuarioParametroDto.Clave);
            if (usuarioinfo == null)
                return null;

            EmpleadoDto empleadoDto = _mapper.Map<EmpleadoDto>(usuarioinfo.Empleado);
            return empleadoDto;
        }

        public PaginacionDto<UsuarioDto> ObtenerUsuarioPaginado(FiltroUsuarioParametroDto filtroUsuarioParametroDto)
        {
            IQueryable<Usuario> consulta = _usuarioRepository.GetQueryable();
            if (!string.IsNullOrWhiteSpace(filtroUsuarioParametroDto.Email))
            {
                consulta = consulta.Where(u => u.Email.Contains(filtroUsuarioParametroDto.Email));
            }
            if (filtroUsuarioParametroDto.IdEmpleado.HasValue)
            {
                consulta = consulta.Where(u => u.IdEmpleado == filtroUsuarioParametroDto.IdEmpleado);
            }

            int totalUsuarios = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalUsuarios / filtroUsuarioParametroDto.Limite);
            var excluirElementos = filtroUsuarioParametroDto.Limite * filtroUsuarioParametroDto.Pagina;
            var UsuariosPaginados = _usuarioRepository.GetPaginado(consulta, filtroUsuarioParametroDto.Limite, excluirElementos);
            var UsuariosDto = _mapper.Map<List<UsuarioDto>>(UsuariosPaginados);
            var paginacionDto = new PaginacionDto<UsuarioDto>
            {
                TotalItems = totalUsuarios,
                PaginaActual = filtroUsuarioParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = UsuariosDto
            };
            return paginacionDto;
        }
    }
}

