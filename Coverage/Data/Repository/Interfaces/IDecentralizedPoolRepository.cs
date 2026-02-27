using Coverage.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coverage.Data.Repositories.Interfaces
{
    public interface IDecentralizedPoolRepository : IGenericRepository<DecentralizedPool>
    {
        Task<IEnumerable<DecentralizedPool?>> GetPoolsByUserIdAsync(int userId);
    }
}
