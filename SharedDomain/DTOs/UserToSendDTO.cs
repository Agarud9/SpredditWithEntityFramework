namespace SharedDomain.DTOs;

public class UserToSendDTO
{
    public string Username { get; private set; }

    public UserToSendDTO(string username)
    {
        Username = username;
    }

    public UserToSendDTO()
    {
        
    }
}