﻿using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("paginado")]
        public async Task<ActionResult<PaginacionDto<UsuarioDto>>> GetUsuarioPaginado([FromBody] FiltroUsuarioParametroDto filtroUsuarioParametroDto)
        {
            PaginacionDto<UsuarioDto> paginadoUsuario = await _usuarioService.ObtenerUsuarioPaginado(filtroUsuarioParametroDto);
            return paginadoUsuario;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDto>>> GetTodoUsuario()
        {
            List<UsuarioDto> usuarioDto = await _usuarioService.ObtenerTodo();
            return Ok(usuarioDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetPorIdUsuario(int id)
        {
            UsuarioDto usuarioDto = await _usuarioService.ObtenerPorId(id);
            return Ok(usuarioDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCrear([FromBody] UsuarioParametroDto usuarioParametroDto)
        {
            int id = await _usuarioService.Crear(usuarioParametroDto);
            return id;
        }

        [HttpPut("{id}")]
        public async Task< ActionResult> PutModificar(int id, [FromBody] UsuarioParametroDto usuarioParametroDto)
        {
            usuarioParametroDto.Id = id;
            await _usuarioService.Modificar(usuarioParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task< ActionResult> Delete(int id)
        {
            await _usuarioService.Eliminar(id);
            return Ok();
        }
    }
}

