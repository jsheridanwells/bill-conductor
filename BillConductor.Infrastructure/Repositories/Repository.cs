using BillConductor.Application.Contracts;
using BillConductor.Core.Abstractions;

namespace BillConductor.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
