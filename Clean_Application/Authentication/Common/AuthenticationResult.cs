using Clean_Domain.Entities;

namespace Clean_Application.Authentication.Common
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}