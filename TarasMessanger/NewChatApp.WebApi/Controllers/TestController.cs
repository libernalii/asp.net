using Microsoft.AspNetCore.Mvc;
using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models;

namespace NewChatApp.WebApi.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public TestController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Test()
    {
        await _usersRepository.Add(new User
        {
            Id = Guid.NewGuid(),
            Nickname = "test",
            Email = "test@gmail.com",
            PasswordHash = "test",
            CreatedAt = DateTime.UtcNow,
        });
        
        return Ok();
    }
}