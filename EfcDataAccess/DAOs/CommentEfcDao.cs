using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedDomain.Models;

namespace EfcDataAccess;

public class CommentEfcDao : ICommentDao
{
    private readonly FileContext context;

    public CommentEfcDao(FileContext context)
    {
        this.context = context;
    }
    public async Task<Comment> CreateAsync(Comment comment)
    {
        EntityEntry<Comment> newComment = await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
        return newComment.Entity;
    }

    public async Task<IEnumerable<Comment>?> GetAllByPostId(int id)
    {
        IEnumerable<Comment>? comments = (await context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.id == id))?.Comments;
        return comments;
    }
}