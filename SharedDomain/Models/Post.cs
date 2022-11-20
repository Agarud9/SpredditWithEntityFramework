using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SharedDomain.Models;

public class Post
{
    public string title { get; set; }
    public string body { get; set; }
    public User user { get; set; }
    public int id { get; set; }

    public int VoteScore => Votes.Any() ? Votes.Select(vote => (int)vote.Type).Sum() : 0;

    [JsonIgnore]
    public ICollection<Vote> Votes { get; set; }
    public ICollection<Comment> Comments { get; set; }

    public Post()
    {
        Votes = new List<Vote>();
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

}