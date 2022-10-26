using Application.LogicIntrefaces;
using Microsoft.AspNetCore.Mvc;
using SharedDomain.DTOs;
using SharedDomain.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic postLogic;
    private readonly IVoteLogic voteLogic;

    public PostController(IPostLogic logic, IVoteLogic voteLogic)
    {
        postLogic = logic;
        this.voteLogic = voteLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreationDTO dto)
    {
        try
        {
            Post post = await postLogic.CreateAsync(dto);
            return Created($"/posts/{post.id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAll(string? title, string? username)
    {
        var filterParams = new PostFilterDTO
        {
            Title = title,
            Username = username
        };
        
        var posts = await postLogic.GetByParameterAsync(filterParams);
        return Ok(posts);
    }

    [HttpPost("{id:int}/upvote")]
    public async Task<IActionResult> UpVotePost(int id, [FromBody] VoteDTO voteDto)
    {
        try
        {
            await voteLogic.UpVote(id, voteDto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("{id:int}/downvote")]
    public async Task<IActionResult> DownVotePost(int id, [FromBody] VoteDTO voteDto)
    {
        try
        {
            await voteLogic.DownVote(id, voteDto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}