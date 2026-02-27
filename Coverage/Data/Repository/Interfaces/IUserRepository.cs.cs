using Coverage.Core.Models;
using System.Threading.Tasks;

namespace Coverage.Data.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> DoesUserExistAsync(string email);
    }
}
