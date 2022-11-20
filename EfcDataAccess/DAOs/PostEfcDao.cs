using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedDomain.DTOs;
using SharedDomain.Models;

namespace EfcDataAccess;

public class PostEfcDao : IPostDao
{
    private readonly FileContext context;

    public PostEfcDao
        (FileContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? post = await context.Posts.FindAsync(id);
        return post;
    }

    public async Task<IEnumerable<Post>> GetByParameterAsync(PostFilterDTO dto)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.user).AsQueryable();
        
        if (!string.IsNullOrEmpty(dto.Title))
        {
            query = query.Where(post => post.title.ToLower().Contains(dto.Title.ToLower()));
        }

        if (!string.IsNullOrEmpty(dto.Username))
        {
            query = query.Where(post => post.user.Username.ToLower().Contains(dto.Username.ToLower()));
        }
        
        List<Post> result = await query.ToListAsync();
        return result;
    }

    public async Task<IEnumerable<Post>?> GetByUserAsync(string username)
    {
        IQueryable<Post> query = context.Posts.AsQueryable()
            .Where(post => post.user.Username.ToLower().Equals(username.ToLower()));
        
        List<Post> result = await query.ToListAsync();
        return result;
    }
}