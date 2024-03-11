using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
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

