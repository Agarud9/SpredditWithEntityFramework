using Application.DaoInterfaces;
using SharedDomain.Models;

namespace FileData.DAOs;

public class CommentDaoImpl : ICommentDao
{
    private readonly FileContext context;

    public CommentDaoImpl(FileContext context)
    {
        this.context = context;
    }
    public Task<Comment> CreateAsync(Comment comment)
    {
        context.Comments.Add(comment);
        context.SaveChange();
        
        return Task.FromResult(comment);
    }
}