﻿using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetTodoUsuario()
        {
            List<UsuarioDto> usuarioDto = _usuarioService.ObtenerTodo();
            return Ok(usuarioDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorIdUsuario(int id)
        {
            UsuarioDto usuarioDto = _usuarioService.ObtenerPorId(id);
            return Ok(usuarioDto);
        }

        [HttpPost]
        public ActionResult<int> PostCrear(UsuarioParametroDto usuarioParametroDto)
        {
            int id = _usuarioService.Crear(usuarioParametroDto);
            return id;
        }

        [HttpPut("{id}")]
        public ActionResult<UsuarioDto> PutModificar(int id, [FromBody] UsuarioParametroDto usuarioParametroDto)
        {
            usuarioParametroDto.Id = id;
            _usuarioService.Modificar(usuarioParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<UsuarioDto> Delete(int id)
        {
            _usuarioService.Eliminar(id);
            return Ok();
        }
    }
}
