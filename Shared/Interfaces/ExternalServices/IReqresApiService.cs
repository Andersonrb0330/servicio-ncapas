using Shared.Models.Reqres;
using Shared.Parameters.ReqresApiServiceClient;

namespace Shared.Interfaces.ExternalServices
{
    public interface IReqresApiService
	{
		Task<List<UsuarioModel>> GetUsuarios(int pagina, int totalElementos);
		Task<UserModel> SaveUser(UserParameterDto userParameterDto);
 	}
}

