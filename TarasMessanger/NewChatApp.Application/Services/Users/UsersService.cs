using System.Text.RegularExpressions;
using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models.Users;
using NewChatApp.Shared.Common;

namespace NewChatApp.Application.Services.Users;

public class UsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UsersService(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
    {
        _usersRepository = usersRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UserDto>> Add(CreateUserRequest request)
    {
        if (!Regex.IsMatch(request.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            return UserErrors.IncorrectEmail;
        
        if (!Regex.IsMatch(request.Nickname, @"^[a-z0-9_-]{3,16}$"))
            return UserErrors.IncorrectNickname;
        
        if (!Regex.IsMatch(request.Password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,16}$"))
            return UserErrors.IncorrectPassword;

        var user = new User
        {
            Id = Guid.NewGuid(),
            Nickname = request.Nickname,
            Email = request.Email,
            PasswordHash = request.Password,
            CreatedAt = DateTime.UtcNow
        };
        
        var userFromDb = await _usersRepository.Add(user);
        _unitOfWork.Commit();
        
        return ToUserDto(userFromDb);
    }
    
    public async Task<Result<UserDto[]>> Search(SearchOptions options)
    {
        var user = await _usersRepository.SearchUsers(options);
        
        return user.Select(ToUserDto).ToArray();
    }

    private UserDto ToUserDto(User user) => new UserDto
    {
        Id = user.Id,
        Email = user.Email,
        Nickname = user.Nickname
    };
}