using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Models.Seguridad;

namespace Application.Implementaciones
{
    public class SeguridadService : ISeguridadService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig;

        public SeguridadService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IOptions<JwtConfig> options)
        {
            _usuarioRepository = usuarioRepository;
            _jwtConfig = options.Value;
            _mapper = mapper;
        }

        public async Task<SeguridadEmpleadoDto> Login(UsuarioParametroDto usuarioParametroDto)
        {
            Usuario usuario = await _usuarioRepository.LoginInfo(usuarioParametroDto.Email,
                                                    usuarioParametroDto.Clave);
            if (usuario == null)
                return null;

            EmpleadoDto empleadoDto = _mapper.Map<EmpleadoDto>(usuario.Empleado);

            // llamamos al metodo 
            string token = GenerateJwtToken(usuario.Empleado);

            var seguridadEmpleadoDto = new SeguridadEmpleadoDto()
            {
                Token = token,
                Empleado = empleadoDto
            };
            return seguridadEmpleadoDto;
        }

        public string GenerateJwtToken(Empleado empleado)
         {
            string roles = GetRolUsuario(empleado.DetalleRolEmpleado);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, empleado.Id.ToString()),
                new Claim(ClaimTypes.Name, empleado.Nombre),
                new Claim(ClaimTypes.Role, roles)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpiryInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetRolUsuario(ICollection<DetalleRolEmpleado> detalleRolEmpleados)
        {
            string roles = string.Empty;
            /*int contador = 0;
            foreach (var detalleRol in detalleRolEmpleados)
            {
                contador++;
                if (contador == 1)
                {
                    roles = detalleRol.Rol.Nombre;
                }
                else
                {
                    roles = roles + "," + detalleRol.Rol.Nombre;
                }
            }*/

            // ,ADMIN,CONTADOR
            foreach (var detalleRol in detalleRolEmpleados)
            {
                roles = roles + "," + detalleRol.Rol.Nombre;
            }
            roles = roles.Substring(1);
            return roles;
        }
    }

}