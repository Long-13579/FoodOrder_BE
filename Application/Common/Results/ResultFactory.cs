namespace Application.Common.Results;

public static class ResultFactory
{
    public static Result<T> From<T>(T value)
    {
        return value;
    }
}
