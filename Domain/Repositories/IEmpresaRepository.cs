using Domain.Entity;

namespace Domain.Repositories
{
    public interface IEmpresaRepository
	{
		List<Empresa> Get();
		Empresa GetById(int id);
		void Create(Empresa empresa);
		void Delete(Empresa empresa);
        bool VerificarEmpresa(int id);
    }
}

 