
using Application.Common.Results;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class Food
    {
        public static Error NotFound(int id) =>
            new (Code: "Food.NotFound",
                 Description: $"Food with id {id} was not found.",
                 Type: ErrorType.NotFound);
    }
}
