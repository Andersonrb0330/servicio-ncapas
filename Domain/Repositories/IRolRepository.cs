using Domain.Entity;

namespace Domain.Repositories
{
    public interface IRolRepository
	{
        Task<bool> ExisteRol(int id);
        Task<List<Rol>> Get();
        Task<Rol> GetById(int id);
        Task Create(Rol rol);
        void Delete(Rol rol);
    }
}

