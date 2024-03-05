using Aplication.Dtos.Request;
using Aplication.Dtos.Response;

namespace Aplication.Interfaces
{
    public interface IPaisService
	{
		List<PaisDto> Get();
		PaisDto GetById(int id);
		int Create( PaisParametroDto paisParametroDto);
		void Update(PaisParametroDto paisParametroDto);
		void Delete(int id);
    }
}

