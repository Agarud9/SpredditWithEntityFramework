using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;

namespace SharedDomain.Models;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    [JsonIgnore]
    public ICollection<Post>? createdPost { get; set; }

    public User()
    {
    }

}