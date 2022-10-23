using SharedDomain.Models;

namespace Application.DaoInterfaces;

public interface IVoteDao
{
    public Task VoteAsync(int postId, Vote vote);
}