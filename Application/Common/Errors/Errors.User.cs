using Application.Common.Results;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error NotFound(int userId) => 
            new (Code: "User.NotFound",
                 Description: $"User with id {userId} was not found.",
                 Type: ErrorType.NotFound);
    }
}
