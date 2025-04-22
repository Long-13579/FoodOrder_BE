using ErrorOr;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error NotFound(string userId) => 
            Error.NotFound(
                code: "User.NotFound",
                description: $"User with id {userId} was not found.");
    }
}
