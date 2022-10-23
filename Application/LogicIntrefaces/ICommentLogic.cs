using SharedDomain.DTOs;
using SharedDomain.Models;

namespace Application.LogicIntrefaces;

public interface ICommentLogic
{
    Task<Comment> CreateAsync(CommentToSendDTO comment);
}