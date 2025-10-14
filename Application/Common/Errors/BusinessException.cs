namespace Application.Common.Errors;

public class BusinessException : Exception
{
    public IEnumerable<string> Errors { get; }

    public BusinessException(string error)
        : base(error)
    {
        Errors = new List<string> { error };
    }

    public BusinessException(IEnumerable<string> errors)
        : base(string.Join("; ", errors))
    {
        Errors = errors;
    }
}
