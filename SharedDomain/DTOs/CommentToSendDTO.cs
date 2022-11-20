
namespace SharedDomain.DTOs;

public class CommentToSendDTO
{
    public string Comment { get; set; }
    public string Username { get;set; }
    public int PostId { get; set; }

    public CommentToSendDTO(string comment,string username, int postId)
    {
        Comment = comment;
        Username = username;
        PostId = postId;
    }

    public CommentToSendDTO()
         {
             
         }

}