using Application.LogicIntrefaces;
using Microsoft.AspNetCore.Mvc;
using SharedDomain.DTOs;
using SharedDomain.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserLogic logic;

    public UserController(IUserLogic logic)
    {
        this.logic = logic;
    }

    [HttpPost]
    public async Task<ActionResult<UserToSendDTO>> CreateAsync(User user)
    {
        try
        {
            UserToSendDTO userToSend = await logic.CreateUser(user);
            return Created($"/users/{userToSend.Username}", userToSend);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}