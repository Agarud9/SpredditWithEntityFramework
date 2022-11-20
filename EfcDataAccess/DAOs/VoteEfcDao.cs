using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using SharedDomain.Models;

namespace EfcDataAccess;

public class VoteEfcDao : IVoteDao
{
    private readonly FileContext context;

    public VoteEfcDao(FileContext context)
    {
        this.context = context;
    }
    public async Task VoteAsync(int postId, Vote vote)
    {

        Vote? existing = context.Votes.SingleOrDefault(v => v.Username == vote.Username && v.PostId==postId);

        if (existing is null)
        {
            await context.Votes.AddAsync(vote);
            await context.SaveChangesAsync();
        }
        else
        {
            context.Votes.Remove(existing);
            context.Votes.Add(vote);
            await context.SaveChangesAsync();
            /*context.ChangeTracker.Clear();
            existing.Type = vote.Type;
            context.Votes.Update(existing);
            await context.SaveChangesAsync();*/
        }
    }

    public async Task<int> GetNumberOfUpVote(int id)
    {
        int number = 0;
        
        
        List<Vote>? votes = new List<Vote>(context.Votes.Where(p => p.PostId== id));

        for (int i = 0; i < votes.Count; i++)
        {
            if (votes[i].Type == VoteType.UpVote)
            {
                number++;
            }
        }

        return number;
    }

    public async Task<int> GetNumberOgDownVote(int id)
    {
        
        int number = 0;

        List<Vote>? votes = new List<Vote>(context.Votes.Where(p => p.PostId== id));

        for (int i = 0; i < votes.Count; i++)
        {
            if (votes[i].Type == VoteType.DownVote)
            {
                number++;
            }
        }

        return number;
    }
}