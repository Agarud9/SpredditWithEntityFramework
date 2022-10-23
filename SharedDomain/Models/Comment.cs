namespace SharedDomain.Models;

public class Comment
{
    public string Body { get; set; }
    public Post Post { get; set; }
    public User User { get; set; }
    public int Id { get; set; }

    public Comment()
    {
        
    }

    public Comment(string body, Post post, User user)
    {
        Body = body;
        Post = post;
        User = user;
    }
}