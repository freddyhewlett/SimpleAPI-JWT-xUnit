using APIDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIDomain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAllAsync();
        Task<bool> ExistsAsync(Guid id);
    }
}
