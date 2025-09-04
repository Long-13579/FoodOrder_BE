namespace Application.Common.Results;

public record Error(string Code, string Description, ErrorType Type)
{
    public static readonly Error None = new("None", "No error.", ErrorType.None);
}
