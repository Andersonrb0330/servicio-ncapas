using Microsoft.Extensions.Options;
using Shared.Interfaces.ExternalServices;
using Shared.Models.FakerApi;
using Shared.ServiceClient;

namespace ExternalServices.ServicesClient
{
    public class FakerApiService : IFakerApiService
	{
        private readonly HttpClient _httpClient;
        private readonly FakerApiSetting _fakerApiSetting;

        public FakerApiService(
            HttpClient httpClient,
            IOptions<ServiceClientSetting> options) 
		{
            _httpClient = httpClient;
            _fakerApiSetting = options.Value.FakerApiSetting;
        }

        public async Task<List<BookModel>> GetBook(int cantidad, string localidad)
        {
            var endPoint = $"{_fakerApiSetting.Host}/api/v1/books?_quantity={cantidad}&_locale={localidad}";

            var request = new HttpRequestMessage(HttpMethod.Get, endPoint);
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Ocurrio un error en el servicio FakerApi: books");
            }

            ResponseFakerApi<BookModel> result = await response.Content.ReadAsAsync<ResponseFakerApi<BookModel>>();
            return result.Data;
        }

        public async Task<List<UserModel>> GetUser(int cantidad, string genero)
        {
            var endPoint = $"{_fakerApiSetting.Host}/api/v1/users?_quantity={cantidad}&_gender={genero}";
            var resquest = new HttpRequestMessage(HttpMethod.Get , endPoint);
            var response = await _httpClient.SendAsync(resquest);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Ocurrio un error en el servicio FakerApi: users");
            }

            ResponseFakerApi<UserModel> result = await response.Content.ReadAsAsync<ResponseFakerApi<UserModel>>();
            return result.Data;
        }

        public async Task<List<ProductModel>> GetProduct(int cantidad, string localidad)
        {
            var endPoint = $"{_fakerApiSetting.Host}/api/v1/products?_quantity={cantidad}&_locale={localidad}";
            var resquest = new HttpRequestMessage(HttpMethod.Get, endPoint);
            var response = await _httpClient.SendAsync(resquest);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Ocurrio un error en el servicio FakerApi: products");
            }

            ResponseFakerApi<ProductModel> result = await response.Content.ReadAsAsync<ResponseFakerApi<ProductModel>>();
            return result.Data;
        }

        public async Task<List<PersonModel>> GetPerson(int cantidad, string localidad, string genero)
        {
            var endPoint = $"{_fakerApiSetting.Host}/api/v1/persons?_quantity={cantidad}&_locale={localidad}&_gender={genero}";
            var resquest = new HttpRequestMessage(HttpMethod.Get, endPoint);
            var response = await _httpClient.SendAsync(resquest);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Ocurrio un error en el servicio FakerApi: persons");
            }

            ResponseFakerApi<PersonModel> result = await response.Content.ReadAsAsync<ResponseFakerApi<PersonModel>>();
            return result.Data;          
        }
    }
}

