using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;

namespace SharedDomain.Models;

public class Post
{
    public string title { get; set; }
    public string body { get; set; }
    public User user { get; set; }
    
    public int id { get; set; }

    public int VoteScore => Votes.Any() ? Votes.Select(vote => (int)vote.Type).Sum() : 0;

    public ICollection<Vote> Votes { get; set; }

    public Post()
    {
    }

    public Post(string title, string body, User user)
    {
        this.title = title;
        this.body = body;
        this.user = user;
        Votes = new List<Vote>();
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

}