using Application.Common.Results;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error NotFound(Guid userId) => 
            new (Code: "User.NotFound",
                 Description: $"User with id {userId} was not found.",
                 Type: ErrorType.NotFound);

        public static Error LoginFailure() => 
            new (Code: "User.LoginFailure",
                 Description: "Invalid username or password.",
                 Type: ErrorType.Unauthorized);
    }
}
