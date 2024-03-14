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
    public class LoginService : ILoginService
	{
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig;

        public LoginService(
            ILoginRepository loginRepository,
            IMapper mapper,
            IOptions<JwtConfig> options)
        {
            _loginRepository = loginRepository;
            _jwtConfig = options.Value;
            _mapper = mapper;
        }

        public async Task<EmpleadoDto> Login(UsuarioParametroDto usuarioParametroDto)
        {
            Usuario usuario = await _loginRepository.Login(usuarioParametroDto.Email,
                                                    usuarioParametroDto.Clave);
            if (usuario == null)
                return null;

            EmpleadoDto empleadoDto = _mapper.Map<EmpleadoDto>(usuario.Empleado);

            // llamamos al mètodo 
            string token = GenerateJwtToken(empleadoDto);

            return empleadoDto;
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

