namespace  Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}

