namespace SharedDomain.Models;

public class Post
{
    public string title { get; set; }
    public string body { get; set; }
    public User user { get; set; }
    
    public int id { get; set; }

    public Post()
    {
    }

    public Post(string title, string body, User user)
    {
        this.title = title;
        this.body = body;
        this.user = user;
    }
}