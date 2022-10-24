using SharedDomain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAllAsync();
}