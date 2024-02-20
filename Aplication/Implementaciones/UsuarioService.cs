using System;
using System.Collections.Generic;
using Aplication.Dtos;
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

        public UsuarioService(IEcommerceContext ecommerceContext, IMapper mapper) {

            _ecommerceContext = ecommerceContext;
            _mapper = mapper;

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

