using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces.ExternalServices;
using Shared.Models.FakerApi;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/faker")]
    public class IntegracionFakerApiController : Controller
    {
        private readonly IFakerApiService _fakerApiService;

        public IntegracionFakerApiController(
            IFakerApiService fakerApiService)
        {
            _fakerApiService = fakerApiService;
        }

        [HttpGet("book")]
        public async Task<ActionResult<List<BookModel>>> GetLibros(int cantidad, string localidad)
        {
            List<BookModel> books = await _fakerApiService.GetBook(cantidad, localidad);
            return books;
        }

        [HttpGet("usuario")]
        public async Task<ActionResult<List<UserModel>>> GetUsuarios(int cantidad, string genero)
        {
            List<UserModel> users = await _fakerApiService.GetUser(cantidad, genero);
            return users;
        }

        [HttpGet("producto")]
        public async Task<ActionResult<List<ProductModel>>> GetProductos(int cantidad, string localidad)
        {
            List<ProductModel> products = await _fakerApiService.GetProduct(cantidad, localidad);
            return products;
        }

        [HttpGet("persona")]
        public async Task<ActionResult<List<PersonModel>>> GetPersonas(int cantidad, string localidad, string genero)
        {
            List<PersonModel> persons = await _fakerApiService.GetPerson(cantidad, localidad, genero);
            return persons;
        }
   
    }
}

