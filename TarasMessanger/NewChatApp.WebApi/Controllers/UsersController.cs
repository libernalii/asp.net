using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewChatApp.Application.Services.Users;
using NewChatApp.Core.Abstractions;

namespace NewChatApp.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : WebApiController
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] SearchOptions options)
    {
        var sw = Stopwatch.StartNew();
        var result = await _usersService.Search(options);

        return OkResponse(result, sw.Elapsed.TotalMilliseconds);
    }
    
    [HttpPost]
    public async Task<IActionResult> Search([FromBody] CreateUserRequest request)
    {
        var sw = Stopwatch.StartNew();
        var result = await _usersService.Add(request);

        return CreatedResponse(result, nameof(Search), sw.Elapsed.TotalMilliseconds);
    }
}