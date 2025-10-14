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

        public static Error NotFound(string identifier) =>
            new(Code: "User.NotFound",
                 Description: $"User with identifier {identifier} was not found.",
                 Type: ErrorType.NotFound);

        public static Error LoginFailure() => 
            new (Code: "User.LoginFailure",
                 Description: "Invalid username or password.",
                 Type: ErrorType.Unauthorized);

        public static Error IdentifierAlreadyExists(string identifier) => 
            new (Code: "User.IdentifierAlreadyExists",
                 Description: $"User with identifier {identifier} already exists.",
                 Type: ErrorType.Conflict);
    }
}
