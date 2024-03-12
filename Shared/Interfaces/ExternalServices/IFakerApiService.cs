using Shared.Models.FakerApi;

namespace Shared.Interfaces.ExternalServices
{
    public interface IFakerApiService
	{
        Task<List<BookModel>> GetBook(int cantidad, string localidad);
        Task<List<UserModel>> GetUser(int cantidad, string genero);
        Task<List<ProductModel>> GetProduct(int cantidad, string localidad);
        Task<List<PersonModel>> GetPerson(int cantidad, string localidad, string genero);


    }
}

