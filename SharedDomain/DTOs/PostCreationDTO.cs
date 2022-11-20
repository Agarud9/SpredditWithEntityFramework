using SharedDomain.Models;

namespace SharedDomain.DTOs;

public class PostCreationDTO
{
    public string Title { get; private set; }
    public string Body { get; private set; }
    public String Username { get; private set; }

    public PostCreationDTO(string title, string body, String username)
    {
        Title = title;
        Body = body;
        Username = username;
    }


}