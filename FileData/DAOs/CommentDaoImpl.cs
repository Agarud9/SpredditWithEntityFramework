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
        int commentId = 1;
        
        if (context.Comments.Any())
        {
            commentId = context.Comments.Max(p => p.Id);
            commentId++;
        }

        comment.Id = commentId;
        
        context.Comments.Add(comment);
        context.SaveChange();
        
        return Task.FromResult(comment);
    }

    public Task<IEnumerable<Comment>> GetAllByPostId(int id)
    {
        Post post = context.Posts.First(post => post.id == id);
        List<Comment> comments = new List<Comment>();
        foreach (var comment in context.Comments)
        {
            if (comment.Post.id == post.id)
            {
                comments.Add(comment);
            }
        }

        IEnumerable<Comment> allComments = comments;

        return Task.FromResult(allComments);
    }
}