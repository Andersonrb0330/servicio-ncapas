using Domain.Entity;

namespace Domain.Repositories
{
    public interface IPaisRepository
	{
		List<Pais> Get();
		Pais GetById(int id);
		int Create(Pais pais);
		void Update(Pais pais);
		void Delete(Pais pais);
	}
}

