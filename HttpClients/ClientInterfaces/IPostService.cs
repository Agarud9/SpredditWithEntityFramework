using SharedDomain.DTOs;
using SharedDomain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAsync(PostFilterDTO? filters = null);
}