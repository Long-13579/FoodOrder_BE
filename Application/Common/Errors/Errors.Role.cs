using Application.Common.Results;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class Role
    {
        public static Error NotFound(string roleName) =>
            new(Code: "Role.NotFound",
                Description: $"Role with name {roleName} was not found.",
                Type: ErrorType.NotFound);
    }
}
