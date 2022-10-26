using SharedDomain.DTOs;
using SharedDomain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAsync(PostFilterDTO? filters = null);
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<IEnumerable<Post>> GetPostsByUserAsync(string username);

    Task<Post> GetPostByIdAsync(int id);
}