using SharedDomain.DTOs;
using SharedDomain.Models;

namespace Application.LogicIntrefaces;

public interface IPostLogic
{
    public Task<Post> CreateAsync(PostCreationDTO dto);
    public Task<IEnumerable<Post>> GetAllAsync();
    public Task<IEnumerable<Post>?> GetByTitleAsync(string title);
    Task<IEnumerable<Post>> GetByParameterAsync(PostFilterDTO dto);
}