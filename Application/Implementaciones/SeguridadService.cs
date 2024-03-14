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

            // llamamos al mètodo 
            string token = GenerateJwtToken(empleadoDto);

            var seguridadEmpleadoDto = new SeguridadEmpleadoDto()
            {
                Token = token,
                Empleado = empleadoDto
            };
            return seguridadEmpleadoDto;
        }

        public string GenerateJwtToken(EmpleadoDto empleadoDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, empleadoDto.Id.ToString()),
                    new Claim(ClaimTypes.Name, empleadoDto.Nombre),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpiryInMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

