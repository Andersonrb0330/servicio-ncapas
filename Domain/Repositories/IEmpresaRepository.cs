using Domain.Entity;

namespace Domain.Repositories
{
    public interface IEmpresaRepository
	{
		Task<List<Empresa>> Get();
		Task<Empresa> GetById(int id);
		Task Create(Empresa empresa);
		void Delete(Empresa empresa);
        Task<bool> VerificarEmpresa(int id);
		Task<List<Empresa>> GetPaginado (IQueryable<Empresa> queryble, int limite, int excluir);
		Task<IQueryable<Empresa>> GetQueryable();
    }
}

 