using System.Reflection.PortableExecutable;

namespace SharedDomain.Models;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }

    public User()
    {
    }

    public User(string username, string password, DateTime date)
    {
        Username = username;
        Password = password;
        DateOfBirth = date;
    }
}