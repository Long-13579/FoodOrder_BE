using ErrorOr;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class Food
    {
        public static Error NotFound(int id) =>
            Error.Conflict(
                code: "Food.NotFound", 
                description: $"Food with id {id} was not found.");
    }
}
