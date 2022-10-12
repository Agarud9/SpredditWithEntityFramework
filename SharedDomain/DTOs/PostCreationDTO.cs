using SharedDomain.Models;

namespace SharedDomain.DTOs;

public class PostCreationDTO
{
    public string Title { get; set; }
    public string Body { get; set; }
    public String Username { get; set; }

    public PostCreationDTO()
    {
    }

    public PostCreationDTO(string title, string body, String username)
    {
        this.Title = title;
        this.Body = body;
        this.Username = username;
    }
    
}