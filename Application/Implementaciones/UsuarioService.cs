using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IValidator<UsuarioParametroDto> _validarUsuario;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public UsuarioService(
            IUsuarioRepository usuarioRepository,        
            IEmpleadoRepository  empleadoRepository,
            IValidator<UsuarioParametroDto> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _empleadoRepository = empleadoRepository;
            _validarUsuario = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDto>> ObtenerTodo()
        {
            List<Usuario> usuarios = await _usuarioRepository.Get();
            List<UsuarioDto> usuarioDto = _mapper.Map<List<UsuarioDto>>(usuarios);
            return usuarioDto;
        }

        public async Task<UsuarioDto> ObtenerPorId(int id)
        {
            Usuario usuario = await _usuarioRepository.GetById(id);
            UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return usuarioDto;
        }

        public async Task<int> Crear(UsuarioParametroDto usuarioParametroDto)
        {
            var validationResult = _validarUsuario.Validate(usuarioParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            bool existeEmail = await _usuarioRepository.VerificarEmail(usuarioParametroDto.Email);
            if (existeEmail == true)
            {
                throw new Exception("El Correo ya existe");
            }

            bool existeUsuarioEmpleado = await _usuarioRepository.VerificarEmpleadoUsuario(usuarioParametroDto.IdEmpleado);
            if (existeUsuarioEmpleado == true)
            {
                throw new Exception("El empleado ya tiene un usuario");
            }

            bool existeEmpleado = await _empleadoRepository.ExisteEmpleado(usuarioParametroDto.IdEmpleado);
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

            await _usuarioRepository.Create(usuario);
            await _unitOfWork.SaveChangesAsync();
            return usuario.Id;
        }

        public async Task Modificar(UsuarioParametroDto usuarioParametroDto)
        {
            Usuario usuario = await _usuarioRepository.GetById(usuarioParametroDto.Id);
            if (usuario == null)
            {
                throw new Exception($"NO existe el Usuario con este ID: {usuarioParametroDto.Id}");
            }
            usuario.Email = usuarioParametroDto.Email;
            usuario.Clave = usuarioParametroDto.Clave;
            usuario.IdEmpleado = usuarioParametroDto.IdEmpleado;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            Usuario usuario = await _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                throw new Exception($"No existe el Usuario con el ID: {id}");
            }
            _usuarioRepository.Delete(usuario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PaginacionDto<UsuarioDto>> ObtenerUsuarioPaginado(FiltroUsuarioParametroDto filtroUsuarioParametroDto)
        {
            IQueryable<Usuario> consulta = await _usuarioRepository.GetQueryable();
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
            var UsuariosPaginados = await _usuarioRepository.GetPaginado(consulta, filtroUsuarioParametroDto.Limite, excluirElementos);
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

