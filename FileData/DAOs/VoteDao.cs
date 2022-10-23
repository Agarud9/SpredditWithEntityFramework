using Application.DaoInterfaces;
using SharedDomain.Models;

namespace FileData.DAOs;

public class VoteDao : IVoteDao
{
    private readonly FileContext fileContext;

    public VoteDao(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }
    
    public Task VoteAsync(int postId, Vote vote)
    {
        Post post = fileContext.Posts.First(post => post.id == postId);

        Vote? v = post.Votes.FirstOrDefault(v => v.Username == vote.Username);

        if (v is null)
            post.Votes.Add(vote);
        else
            v.Type = vote.Type;
        
        fileContext.SaveChange();
        
        return Task.CompletedTask;
    }
}