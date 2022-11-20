using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SharedDomain.Models;

public class Comment
{
    public string Body { get; set; }
    [JsonIgnore]
    public Post Post { get; set; }
    public string Username { get; set; }
    public int Id { get; set; }

    public Comment()
    {
    }

    public Comment(string body, Post post, string username)
    {
        Body = body;
        Post = post;
        Username = username;
    }
}