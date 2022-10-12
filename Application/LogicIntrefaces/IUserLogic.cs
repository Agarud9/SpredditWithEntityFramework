using SharedDomain.DTOs;
using SharedDomain.Models;

namespace Application.LogicIntrefaces;

public interface IUserLogic
{
    public Task<UserToSendDTO> CreateUser(User user);
}