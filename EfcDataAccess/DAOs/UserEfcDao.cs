using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedDomain.DTOs;
using SharedDomain.Models;

namespace EfcDataAccess;

public class UserEfcDao : IUserDao
{
    private readonly FileContext context;

    public UserEfcDao(FileContext context)
    {
        this.context = context;
    }
    public async Task<UserToSendDTO> CreateUserAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        UserToSendDTO userToSend = new UserToSendDTO(newUser.Entity.Username);
        return userToSend;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));
        return user;
    }
}