using Microsoft.AspNetCore.Mvc;
using NewChatApp.Application.Services.Users;
using NewChatApp.Core.Abstractions;

namespace NewChatApp.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] SearchOptions options)
    {
        var result = await _usersService.Search(options);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> Search([FromBody] CreateUserRequest request)
    {
        var result = await _usersService.Add(request);

        return result.IsSuccess
            ? CreatedAtAction(nameof(Search), new { }, result.Value)
            : BadRequest(result.Error);
    }
}