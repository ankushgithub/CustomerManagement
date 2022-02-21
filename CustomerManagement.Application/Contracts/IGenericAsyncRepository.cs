using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Contracts
{
    public interface IGenericAsyncRepository<T> where T: class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
