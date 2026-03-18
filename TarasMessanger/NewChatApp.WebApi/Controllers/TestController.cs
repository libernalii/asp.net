using Microsoft.AspNetCore.Mvc;
using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models;

namespace NewChatApp.WebApi.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TestController(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
    {
        _usersRepository = usersRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Test()
    {
        await _usersRepository.Add(new User
        {
            Id = Guid.NewGuid(),
            Nickname = "transaction_user_new",
            Email = "",
            PasswordHash = "",
            CreatedAt = DateTime.Now
        });
        
        await _usersRepository.Add(new User
        {
            Id = Guid.NewGuid(),
            Nickname = "transaction_user_new_1",
            Email = "",
            PasswordHash = "",
            CreatedAt = DateTime.Now
        });
        
        await _usersRepository.Add(new User
        {
            Id = Guid.NewGuid(),
            Nickname = "transaction_user_new_2",
            Email = "",
            PasswordHash = "",
            CreatedAt = DateTime.Now
        });
        
        _unitOfWork.Commit();
        
        var users = await _usersRepository.SearchUsers(new SearchOptions("test", 10, 1));
        
        return Ok(users);
    }
}