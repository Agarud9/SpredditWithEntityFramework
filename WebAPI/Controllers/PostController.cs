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

    public PostController(IPostLogic logic)
    {
        postLogic = logic;
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
    public async Task<ActionResult<IEnumerable<Post>>> GetAll()
    {
        var posts = await postLogic.GetAllAsync();
        return Ok(posts);
    }

    [HttpGet]
    [Route("getByTitle")]
    public async Task<ActionResult<IEnumerable<Post>?>> GetByTitle(string title)
    {
        try
        { 
            IEnumerable<Post>? posts = await postLogic.GetByTitleAsync(title); 
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
        
    }
}