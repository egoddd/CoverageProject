using Coverage.Core.DTOs;
using Coverage.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coverage.Services.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(CreateUserDTO userDto);
    }
}
