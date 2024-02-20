using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Dtos;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/empresas")]
    public class EmpresaController : Controller
    {

        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService) {

            _empresaService = empresaService;
        }

        [HttpGet]
        public ActionResult<List<EmpresaDto>> GetTodoEmpresa() {

            List<EmpresaDto> empresaDto = _empresaService.ObtenerTodo();

            return Ok(empresaDto);
        }


        [HttpGet("{id}")]
        public ActionResult<EmpresaDto> GetPorIdEmpresa(int id) {

            EmpresaDto empresaDto = _empresaService.ObtenerPorId(id);

            return Ok(empresaDto);

        }



    }
}

