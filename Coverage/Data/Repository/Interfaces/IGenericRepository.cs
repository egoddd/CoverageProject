using Coverage.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coverage.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity); // Updated to return Task<T>
        Task<T> UpdateAsync(T entity); // Updated to return Task<T>
        Task DeleteAsync(T entity);
        Task DeleteAsync(int id); // Optional: Add if needed to delete by ID

    }
}
