namespace NewChatApp.Core.Models.Users;

using NewChatApp.Shared.Common;

public static class UserErrors
{
    public static Error IncorrectNickname => new Error("Incorrect nickname", "Nickname");
    public static Error IncorrectPassword => new Error("Incorrect password", "Password");
    public static Error IncorrectEmail => new Error("Incorrect email", "Email");
}