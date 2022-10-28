using SharedDomain.DTOs;
using SharedDomain.Models;

namespace Application.DaoInterfaces
{
    public interface IPostDao
    {
        public Task<Post> CreateAsync(Post post);
        public Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetByTitleAsync(string title);
        Task<Post?> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetByParameterAsync(PostFilterDTO dto);
        public Task <IEnumerable<Post>> GetByUserAsync(string username);
    }
}