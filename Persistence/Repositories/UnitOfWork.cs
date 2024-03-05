using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Commons
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceContext _ecommerceContext;

        public UnitOfWork(
            EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public void Dispose()
        {
            _ecommerceContext?.Dispose();
        }

        public void SaveChanges()
        {
            _ecommerceContext.SaveChanges();
        }
    }
}

