using BillConductor.Core.Abstractions;

namespace BillConductor.Application.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetById(Guid id);
        void Insert(T entity);
    }
}
