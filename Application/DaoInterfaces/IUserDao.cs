using SharedDomain.DTOs;
using SharedDomain.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    public Task<UserToSendDTO> CreateUserAsync(User user);
    public Task<User?> GetByUsernameAsync(string username);
}