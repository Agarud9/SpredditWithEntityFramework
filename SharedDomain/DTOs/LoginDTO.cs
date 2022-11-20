namespace SharedDomain.DTOs;

public class LoginDTO
{
    public string Username { get; private set; }
    public string Password { get; private set; }

    public LoginDTO(string username, string password)
    {
        Username = username;
        Password = password;
    }

}