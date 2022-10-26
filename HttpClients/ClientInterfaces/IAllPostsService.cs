using SharedDomain.Models;

namespace HttpClients.ClientInterfaces;

public interface IAllPostsService
{
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<IEnumerable<Post>> GetPostsByUserAsync(string username);
}