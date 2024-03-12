using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shared.Interfaces.ExternalServices;
using Shared.Models.Reqres;
using Shared.Parameters.ReqresApiServiceClient;
using Shared.ServiceClient;

namespace ExternalServices.ServicesClient
{
    public class ReqresApiService : IReqresApiService
	{
        private readonly ReqresApiSetting _reqresApiSetting;
        private readonly HttpClient _httpClient;

        public ReqresApiService(
            IOptions<ServiceClientSetting> options,
            HttpClient httpClient)
		{
            _reqresApiSetting = options.Value.ReqresApiSetting;
            _httpClient = httpClient;
        }

        public async Task<List<UsuarioModel>> GetUsuarios(int pagina, int totalElementos)
        {
            var endPoint = $"{_reqresApiSetting.Host}/api/users?page={pagina}&per_page={totalElementos}";

            var request = new HttpRequestMessage(HttpMethod.Get, endPoint);
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Ocurrio un error en el servicio  Reqres: Usuario");
            }

            ResponseReqres<UsuarioModel> result = await response.Content.ReadAsAsync<ResponseReqres<UsuarioModel>>();
            return result.Data;
        }

        public async Task<UserModel> SaveUser (UserParameterDto userParameterDto)
        {
            var endPoint = $"{_reqresApiSetting.Host}/api/users";
            var request = new HttpRequestMessage(HttpMethod.Post, endPoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(userParameterDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception("Ocurrio un error en el servicio  Reqres: User");
            }

            UserModel result = await response.Content.ReadAsAsync<UserModel>();
            return result;
        }
    }
}

